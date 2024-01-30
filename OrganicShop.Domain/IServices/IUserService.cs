using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.UserDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums.EntityResults;

namespace OrganicShop.Domain.IServices
{
    public interface IUserService
    {
        Task<PageDto<User, UserListDto, long>> GetAll(FilterUserDto filter, SortUserDto sort, PagingDto paging);

        Task<EntityResultCreate> Create(CreateUserDto create);

        Task<EntityResultUpdate> Update(UpdateUserDto update);
        
        Task<EntityResultDelete> Delete(long Id);

        Task<EntityResultUpdate> ChangePassword(ChangePasswordDto changePassword);



        
    }
}
