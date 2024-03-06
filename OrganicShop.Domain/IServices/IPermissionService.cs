using OrganicShop.Domain.Dtos.Combo;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.PermissionDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Response;

namespace OrganicShop.Domain.IServices
{
    public interface IPermissionService : IService<Permission>
    {
        Task<PageDto<Permission,PermissionListDto,byte>> GetAll(FilterPermissionDto? filter = null, SortPermissionDto? sort = null,PagingDto? paging = null);

        Task<ServiceResponse> Create(CreatePermissionDto create);

        Task<ServiceResponse> Update(UpdatePermissionDto update);
        
        Task<ServiceResponse> Delete(byte delete);

        Task<List<ComboDto<Permission>>> GetCombos();
    }
}
