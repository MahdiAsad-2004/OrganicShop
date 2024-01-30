using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.PropertyDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums.EntityResults;

namespace OrganicShop.Domain.IServices
{
    public interface IPropertyService
    {
        Task<PageDto<Property,PropertyListDto,int>> GetAll(FilterPropertyDto filter , SortPropertyDto sort , PagingDto paging);

        Task<EntityResultCreate> Create(CreatePropertyDto create);

        Task<EntityResultUpdate> Update(UpdatePropertyDto update);
        
        Task<EntityResultDelete> Delete(int delete);
        
    }
}
