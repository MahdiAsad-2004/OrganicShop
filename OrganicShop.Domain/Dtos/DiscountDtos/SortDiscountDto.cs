using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Entities;

namespace OrganicShop.Domain.Dtos.DiscountDtos
{
    public class SortDiscountDto : BaseSortDto<Discount , int>
    {
        public bool? Count { get; set; }
        public bool? Percent { get; set; }
        public bool? FixedValue { get; set; }
    }



}
