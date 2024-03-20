using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Enums;
using OrganicShop.Domain.Enums.SortTypes;

namespace OrganicShop.Domain.Dtos.CoProductDtos
{
    public class FilterCoProductDto : BaseFilterDto<Entities.CoProduct, long>
    {
        public long? ProductId { get; set; }
        public long? BasketId { get; set; }
        public long? OrderId { get; set; }
        public bool? IsOrdered { get; set; }
        public CoProductSortType SortBy { get; set; } = CoProductSortType.None;


        public IQueryable<CoProduct> ApplySortType(IQueryable<CoProduct> query)
        {

            switch (SortBy)
            {
                case CoProductSortType.None:
                    break;

                case CoProductSortType.Newest:
                    query = query.OrderByDescending(a => a.Id);
                    break;

                case CoProductSortType.LatestChange:
                    query = query.OrderByDescending(a => a.BaseEntity.LastModified);
                    break;

                case CoProductSortType.Oldest:
                    query = query.OrderBy(a => a.Id);
                    break;

                case CoProductSortType.Price:
                    query = query.OrderBy(a => a.Price);
                    break;

                case CoProductSortType.PriceDesc:
                    query = query.OrderByDescending(a => a.Price);
                    break;

                case CoProductSortType.Count:
                    query = query.OrderBy(a => a.Count);
                    break;

                case CoProductSortType.CountDesc:
                    query = query.OrderByDescending(a => a.Count);
                    break;
            }

            return query;
        }
    }

}
