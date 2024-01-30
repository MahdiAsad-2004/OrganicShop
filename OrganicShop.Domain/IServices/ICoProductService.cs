using OrganicShop.Domain.Dtos.CoProductDtos;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums.EntityResults;

namespace OrganicShop.Domain.IServices
{
    public interface ICoProductService
    {
        Task<PageDto<CoProduct, CoProductListDto, long>> GetAll(FilterCoProductDto filter, SortCoProductDto sort, PagingDto paging);

        Task<EntityResultCreate> Create(CoProductCreateDto create);

        Task<EntityResultUpdate> Update(UpdateCoProductDto update);
        
        Task<EntityResultDelete> Delete(long id);
        
    }
}
