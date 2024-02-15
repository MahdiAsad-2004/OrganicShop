
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.UserDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Response;

namespace OrganicShop.Domain.IServices
{
    public interface IUserService : IService<User>
    {
        Task<PageDto<User, UserListDto, long>> GetAll(FilterUserDto filter, SortUserDto sort, PagingDto paging);

        Task<ServiceResponse> Create(CreateUserDto create);

        Task<ServiceResponse> Update(UpdateUserDto update);
        
        Task<ServiceResponse> Delete(long Id);

        Task<ServiceResponse> ChangePassword(ChangePasswordDto changePassword);



        
    }
}
