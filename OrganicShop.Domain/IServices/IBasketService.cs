using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.BaketDtos;
using OrganicShop.Domain.Response;

namespace OrganicShop.Domain.IServices
{
    public interface IBasketService : IService<Basket>
    {
        Task<PageDto<Basket, BasketListDto, long>> GetAll(FilterBasketDto filter, SortBasketDto sort, PagingDto paging);

        Task<ServiceResponse> Create(CreateBasketDto create);

        Task<ServiceResponse> Update(UpdateBasketDto update);

        //Task<DeleteEntityResult> Delete(BasketDeleteDto delete);

        //Task<ServiceResponse> AddToBasket(CoProduct coProduct);

        //Task<ServiceResponse> AddToBasket(List<CoProduct> coProducts);
    }
}
