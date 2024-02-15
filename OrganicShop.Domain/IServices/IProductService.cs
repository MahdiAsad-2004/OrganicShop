using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.ProductDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Response;

namespace OrganicShop.Domain.IServices
{
    public interface IProductService : IService<Product>
    {
        Task<PageDto<Product,ProductListDto,long>> GetAll(FilterProductDto filter, SortProductDto sort,PagingDto paging);

        Task<ServiceResponse> Create(CreateProductDto create);

        Task<ServiceResponse> Update(UpdateProductDto update);
        
        Task<ServiceResponse> Delete(long delete);
        
    }
}
