using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums;

namespace OrganicShop.Domain.Dtos.DiscountDtos
{
    public class SortDiscountDto : BaseSortDto<Discount , int>
    {
        public SortOrder? Count { get; set; } = null;
        public SortOrder? Percent { get; set; } = null;
        public SortOrder? FixedValue { get; set; } = null;
    }



}
