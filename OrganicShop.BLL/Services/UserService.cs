using Microsoft.EntityFrameworkCore;
using OrganicShop.BLL.Mappers;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.UserDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums.EntityResults;
using OrganicShop.Domain.IRepositories;
using OrganicShop.Domain.IServices;
using System.Dynamic;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace OrganicShop.BLL.Services
{
    public class UserService : IUserService
    {
        #region ctor

        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        #endregion



        public async Task<PageDto<User,UserListDto,long>> GetAll(FilterUserDto filter, SortUserDto sort,PagingDto paging)
        {
            var query = _userRepository.GetQueryable()
                .Include(a => a.Addresses)
                .AsQueryable();

            #region filter

            query = filter.ApplyBaseFilters(query);

            if (filter.Name != null)
                query = query.Where(a => EF.Functions.Like(a.Name, $"%{filter.Name}%"));

            if (filter.PhoneNumber != null)
                query = query.Where(a => EF.Functions.Like(a.PhoneNumber, $"%{filter.PhoneNumber}%"));

            if (filter.Name != null)
                query = query.Where(a => EF.Functions.Like(a.Email, $"%{filter.Email}%"));

            #endregion


            #region sort

            query = sort.ApplyBaseSort(query);

            if (sort.Name == true) query = query.OrderBy(a => a.Name);
            if (sort.Name == false) query = query.OrderByDescending(a => a.Name);

            #endregion


            PageDto<User, UserListDto, long> pageDto = new();
            pageDto.List = pageDto.SetPaging(query, paging).Select(a => a.ToListDto()).ToList();
            
            return pageDto;
        }



        public async Task<EntityResultCreate> Create(CreateUserDto create)
        {
            if (await _userRepository.GetQueryable().AnyAsync(a => a.PhoneNumber == create.PhoneNumber))
                return EntityResultCreate.PhoneNumberExist;

            if(await _userRepository.GetQueryable().AnyAsync(a => a.Email == create.Email))
                return EntityResultCreate.EmailExist;

            User user = create.ToModel();
            await _userRepository.Add(user,1);
            return EntityResultCreate.success;
        }



        public async Task<EntityResultUpdate> Update(UpdateUserDto update)
        {
            if (await _userRepository.GetQueryable().AnyAsync(a => a.Id != update.Id && a.Email == update.Email))
                return EntityResultUpdate.EmailExist;

            User? user = await _userRepository.GetAsTracking(update.Id);
            
            if (user == null)
                return EntityResultUpdate.NotFound;

            await _userRepository.Update(update.ToModel(user), 1);
            return EntityResultUpdate.success;
        }



        public async Task<EntityResultDelete> Delete(long delete)
        {
            User? user = await _userRepository.GetAsTracking(delete);

            if (user == null)
                return EntityResultDelete.NotFound;

            await _userRepository.SoftDelete(user,1);
            return EntityResultDelete.success;
        }



        public async Task<EntityResultUpdate> ChangePassword(ChangePasswordDto changePassword)
        {
            User? user = await _userRepository.GetAsNoTracking(changePassword.Id);

            if (user == null)
                return EntityResultUpdate.NotFound;

            if (user.Password != changePassword.Password)
                return EntityResultUpdate.WrongPassword;

            user = await _userRepository.GetAsTracking(changePassword.Id);
            user!.Password = changePassword.NewPassword;
            await _userRepository.Update(user, 1);
            return EntityResultUpdate.success;
        }



    }
}
