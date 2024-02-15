using OrganicShop.Domain.Dtos.Base;

namespace OrganicShop.Domain.Dtos.ProductDtos
{
    public class SortProductDto : BaseSortDto<Entities.Product, long>
    {
        public bool? Title { get; set; } = null;
        public bool? Price { get; set; } = null;
        public bool? SoldCount { get; set; } = null;
        public bool? Discount { get; set; } = null;
    }


}
