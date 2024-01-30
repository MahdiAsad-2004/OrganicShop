using OrganicShop.Domain.Dtos.Base;

namespace OrganicShop.Domain.Dtos.CoProductDtos
{
    public class CoProductListDto : BaseDto<long>
    {
        public long ProductId { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
        public int? UpdatedPrice { get; set; }
        public long? BasketId { get; set; }
    }

}
