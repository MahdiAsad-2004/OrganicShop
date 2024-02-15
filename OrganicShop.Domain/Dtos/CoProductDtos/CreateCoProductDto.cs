using OrganicShop.Domain.Dtos.Base;

namespace OrganicShop.Domain.Dtos.CoProductDtos
{
    public class CreateCoProductDto : BaseDto
    {
        public long ProductId { get; set; }
        public long BasketId { get; set; }
        public int Count { get; set; }
    }

}
