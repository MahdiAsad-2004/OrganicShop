using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.PermissionDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums.EntityResults;

namespace OrganicShop.Domain.IServices
{
    public interface IPermissionService
    {
        Task<PageDto<Permission,PermissionListDto,byte>> GetAll(FilterPermissionDto filter, SortPermissionDto sort,PagingDto paging);

        Task<EntityResultCreate> Create(CreatePermissionDto create);

        Task<EntityResultUpdate> Update(UpdatePermissionDto update);
        
        Task<EntityResultDelete> Delete(byte delete);
        
    }
}
