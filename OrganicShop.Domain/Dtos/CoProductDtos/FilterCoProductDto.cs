using OrganicShop.Domain.Dtos.Base;

namespace OrganicShop.Domain.Dtos.CoProductDtos
{
    public class FilterCoProductDto : BaseFilterDto<Entities.CoProduct, long>
    {
        public long? ProductId { get; set; }
        public long? BasketId { get; set; }
        public long? OrderId { get; set; }
        public bool? IsOrdered { get; set; }
    }

}
