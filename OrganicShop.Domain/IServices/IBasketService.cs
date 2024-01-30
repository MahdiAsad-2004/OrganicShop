using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums.EntityResults;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.BaketDtos;

namespace OrganicShop.Domain.IServices
{
    public interface IBasketService
    {
        Task<PageDto<Basket, BasketListDto, long>> GetAll(FilterBasketDto filter, SortBasketDto sort, PagingDto paging);

        Task<EntityResultCreate> Create(CreateBasketDto create);

        Task<EntityResultUpdate> Update(UpdateBasketDto update);

        //Task<DeleteEntityResult> Delete(BasketDeleteDto delete);

        //Task<EntityResultUpdate> AddToBasket(CoProduct coProduct);

        //Task<EntityResultUpdate> AddToBasket(List<CoProduct> coProducts);
    }
}
