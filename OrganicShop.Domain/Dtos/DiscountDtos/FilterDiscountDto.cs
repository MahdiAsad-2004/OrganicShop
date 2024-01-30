using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Entities;

namespace OrganicShop.Domain.Dtos.DiscountDtos
{
    public class FilterDiscountDto : BaseFilterDto<Discount,int>
    {
        public long? UserId { get; set; }
        public long? ProductId { get; set; }
        public bool? IsDefault { get; set; }
        public bool? IsPercent { get; set; }

    }



}
