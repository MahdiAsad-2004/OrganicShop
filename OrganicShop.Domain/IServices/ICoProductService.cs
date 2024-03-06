using OrganicShop.Domain.Dtos.CoProductDtos;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Response;

namespace OrganicShop.Domain.IServices
{
    public interface ICoProductService : IService<CoProduct>
    {
        Task<PageDto<CoProduct, CoProductListDto, long>> GetAll(FilterCoProductDto? filter = null, SortCoProductDto? sort = null, PagingDto? paging = null);

        Task<ServiceResponse> Create(CreateCoProductDto create);

        Task<ServiceResponse> Update(UpdateCoProductDto update);
        
        Task<ServiceResponse> Delete(long id);
        
    }
}
