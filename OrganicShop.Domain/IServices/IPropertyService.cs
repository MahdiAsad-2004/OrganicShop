using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.PropertyDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Response;

namespace OrganicShop.Domain.IServices
{
    public interface IPropertyService : IService<Property>
    {
        Task<PageDto<Property,PropertyListDto,int>> GetAll(FilterPropertyDto filter , SortPropertyDto sort , PagingDto paging);

        Task<ServiceResponse> Create(CreatePropertyDto create);

        Task<ServiceResponse> Update(UpdatePropertyDto update);
        
        Task<ServiceResponse> Delete(int delete);
        
    }
}
