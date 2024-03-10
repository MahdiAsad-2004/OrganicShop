using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Enums;

namespace OrganicShop.Domain.Dtos.CoProductDtos
{
    public class SortCoProductDto : BaseSortDto<Entities.CoProduct, long>
    {
        public SortOrder? Price { get; set; } = null;
        public SortOrder? Count { get; set; } = null;
    }

}
