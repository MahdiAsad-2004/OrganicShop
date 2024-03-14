using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Response;
using OrganicShop.Domain.Dtos.BasketDtos;

namespace OrganicShop.Domain.IServices
{
    public interface IBasketService : IService<Basket>
    {
        Task<ServiceResponse<PageDto<Basket, BasketListDto, long>>> GetAll(FilterBasketDto? filter = null, SortBasketDto? sort = null, PagingDto? paging = null);

        Task<ServiceResponse<Empty>> Create(CreateBasketDto create);

        Task<ServiceResponse<Empty>> Update(UpdateBasketDto update);


        //Task<DeleteEntityResult> Delete(BasketDeleteDto delete);

        //Task<ServiceResponse> AddToBasket(CoProduct coProduct);

        //Task<ServiceResponse> AddToBasket(List<CoProduct> coProducts);
    }
}
