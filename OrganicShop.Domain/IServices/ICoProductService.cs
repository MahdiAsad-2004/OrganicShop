using OrganicShop.Domain.Dtos.CoProductDtos;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Response;

namespace OrganicShop.Domain.IServices
{
    public interface ICoProductService : IService<CoProduct>
    {
        Task<ServiceResponse<PageDto<CoProduct, CoProductListDto, long>>> GetAll(FilterCoProductDto? filter = null, PagingDto? paging = null);

        Task<ServiceResponse<Empty>> Create(CreateCoProductDto create);

        Task<ServiceResponse<Empty>> Update(UpdateCoProductDto update);
        
        Task<ServiceResponse<Empty>> Delete(long id);
        
    }
}
