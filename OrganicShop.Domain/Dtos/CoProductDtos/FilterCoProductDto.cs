using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Enums;

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
