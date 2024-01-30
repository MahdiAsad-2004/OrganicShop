using OrganicShop.Domain.Dtos.Base;

namespace OrganicShop.Domain.Dtos.DiscountDtos
{
    public class DiscountListDto : BaseDto<int>
    {
        public bool IsDefault { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public string? Code { get; set; }
        public int? Count { get; set; }
        public int? FixedValue { get; set; }
        public int? Percent { get; set; }
    }



}
