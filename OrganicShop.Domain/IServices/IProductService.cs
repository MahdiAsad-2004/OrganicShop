using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.ProductDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums.EntityResults;

namespace OrganicShop.Domain.IServices
{
    public interface IProductService
    {
        Task<PageDto<Product,ProductListDto,long>> GetAll(FilterProductDto filter, SortProductDto sort,PagingDto paging);

        Task<EntityResultCreate> Create(CreateProductDto create);

        Task<EntityResultUpdate> Update(UpdateProductDto update);
        
        Task<EntityResultDelete> Delete(long delete);
        
    }
}
