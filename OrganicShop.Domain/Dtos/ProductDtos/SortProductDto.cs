using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Enums;

namespace OrganicShop.Domain.Dtos.ProductDtos
{
    public class SortProductDto : BaseSortDto<Entities.Product, long>
    {
        public SortOrder? Title { get; set; } = null;
        public SortOrder? Price { get; set; } = null;
        public SortOrder? SoldCount { get; set; } = null;
        public SortOrder? Discount { get; set; } = null;
    }


}
