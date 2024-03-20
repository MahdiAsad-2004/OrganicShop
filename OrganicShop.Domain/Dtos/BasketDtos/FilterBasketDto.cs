using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Enums;
using OrganicShop.Domain.Enums.SortTypes;

namespace OrganicShop.Domain.Dtos.BasketDtos
{
    public class FilterBasketDto : BaseFilterDto<Basket,long>
    {
        public long? UserId { get; set; }
        public BasketSortType SortBy { get; set; } = BasketSortType.None;

        public IQueryable<Basket> ApplySortType(IQueryable<Basket> query)
        {

            switch (SortBy)
            {
                case BasketSortType.None:
                    break;

                case BasketSortType.Newest:
                    query = query.OrderByDescending(a => a.Id);
                    break;

                case BasketSortType.LatestChange:
                    query = query.OrderByDescending(a => a.BaseEntity.LastModified);
                    break;

                case BasketSortType.Oldest:
                    query = query.OrderBy(a => a.Id);
                    break;

                case BasketSortType.TotalPrice:
                    query = query.OrderBy(a => a.TotalPrice);
                    break;

                case BasketSortType.TotalPriceDesc:
                    query = query.OrderByDescending(a => a.TotalPrice);
                    break;
            }

            return query;
        }


    }





}
