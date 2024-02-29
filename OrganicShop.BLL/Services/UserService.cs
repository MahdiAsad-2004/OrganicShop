using Microsoft.EntityFrameworkCore;
using OrganicShop.BLL.Mappers;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.UserDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.IRepositories;
using OrganicShop.Domain.IServices;
using OrganicShop.Domain.Enums.EntityResults;
using System.Dynamic;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using OrganicShop.Domain.Response;
using AutoMapper;
using OrganicShop.Domain.Dtos.AddressDtos;

namespace OrganicShop.BLL.Services
{
    public class UserService : IUserService
    {
        #region ctor

        private readonly IMapper _Mapper;
        private readonly IUserRepository _userRepository;
        public Message<User> _Message { get; } = new Message<User>();

        public UserService(IMapper mapper,IUserRepository userRepository)
        {
            _Mapper = mapper;
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
            pageDto.List = pageDto.SetPaging(query, paging).Select(a => _Mapper.Map<UserListDto>(a)).ToList();
            pageDto.Pager = pageDto.SetPager(query, paging);

            return pageDto;
        }



        public async Task<ServiceResponse> Create(CreateUserDto create)
        {
            if (await _userRepository.GetQueryable().AnyAsync(a => a.PhoneNumber == create.PhoneNumber))
                return new ServiceResponse(EntityResult.EntityExist, _Message.EntityExist(create,a => nameof(a.PhoneNumber)));

            if (await _userRepository.GetQueryable().AnyAsync(a => a.Email == create.Email))
                return new ServiceResponse(EntityResult.EntityExist, _Message.EntityExist(create, a => nameof(a.Email)));


            // if currentUser has permission to set userUermissions , permissions sets here 


            User user = _Mapper.Map<User>(create);
            await _userRepository.Add(user,1);
            return new ServiceResponse(EntityResult.Success, _Message.SuccessCreate());
        }



        public async Task<ServiceResponse> Update(UpdateUserDto update)
        {
            //if (await _userRepository.GetQueryable().AnyAsync(a => a.Id != update.Id && a.Email == update.Email))
            //    return new ServiceResponse(EntityResult.EntityExist, _Message.EntityExist(update, a => nameof(a.Email)));

            User? user = await _userRepository.GetAsTracking(update.Id);
            
            if (user == null)
                return new ServiceResponse(EntityResult.NotFound, _Message.NotFound());

            await _userRepository.Update(_Mapper.Map<User>(update), 1);
            return new ServiceResponse(EntityResult.Success, _Message.SuccessUpdate());
        }



        public async Task<ServiceResponse> Delete(long delete)
        {
            User? user = await _userRepository.GetAsTracking(delete);

            if (user == null)
                return new ServiceResponse(EntityResult.NotFound, _Message.NotFound());

            await _userRepository.SoftDelete(user,1);
            return new ServiceResponse(EntityResult.Success, _Message.SuccessDelete());
        }



        public async Task<ServiceResponse> ChangePassword(ChangePasswordDto changePassword)
        {
            User? user = await _userRepository.GetAsNoTracking(changePassword.Id);

            if (user == null)
                return new ServiceResponse(EntityResult.NotFound, _Message.NotFound());

            if (user.Password != changePassword.Password)
                return new ServiceResponse(EntityResult.Failed, "رمز عبور نادرست است");

            user = await _userRepository.GetAsTracking(changePassword.Id);
            user!.Password = changePassword.NewPassword;
            await _userRepository.Update(user, 1);
            return new ServiceResponse(EntityResult.Success, "رمز عبور با موفقیت تغییر یافت");
        }



        public Task<bool> IsEmailExist(string email)
        {
            email = email.Trim().ToLower();
            return Task.FromResult(_userRepository.GetQueryable().Any(a => a.Email == email));
        }



        public Task<bool> IsPhoneNumberExist(string phoneNumber)
        {
            phoneNumber = phoneNumber.Trim().ToLower();
            return Task.FromResult(_userRepository.GetQueryable().Any(a => a.PhoneNumber == phoneNumber));
        }
    }
}
