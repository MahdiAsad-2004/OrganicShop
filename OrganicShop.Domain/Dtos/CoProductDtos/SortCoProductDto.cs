using OrganicShop.Domain.Dtos.Base;

namespace OrganicShop.Domain.Dtos.CoProductDtos
{
    public class SortCoProductDto : BaseSortDto<Entities.CoProduct, long>
    {
        public bool? Price { get; set; }
        public bool? Count { get; set; }
    }

}
