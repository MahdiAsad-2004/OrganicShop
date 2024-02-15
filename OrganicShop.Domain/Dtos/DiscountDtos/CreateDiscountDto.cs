using OrganicShop.Domain.Dtos.Base;

namespace OrganicShop.Domain.Dtos.DiscountDtos
{
    public class CreateDiscountDto : BaseDto
     {
        public bool IsDefault { get; set; }
        public string? Code { get; set; }
        public int? Count { get; set; }
        public int? FixedValue { get; set; }
        public int? Percent { get; set; }
        public IEnumerable<long> UsersIds { get; set; } = Enumerable.Empty<long>();
        public IEnumerable<long> ProducsIds { get; set; } = Enumerable.Empty<long>();
    }



}
