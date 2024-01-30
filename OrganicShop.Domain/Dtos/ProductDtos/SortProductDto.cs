using OrganicShop.Domain.Dtos.Base;

namespace OrganicShop.Domain.Dtos.ProductDtos
{
    public class SortProductDto : BaseSortDto<Entities.Product, long>
    {
        public bool? Title { get; set; }
        public bool? Price { get; set; }
        public bool? SoldCount { get; set; }
        public bool? Discount { get; set; }
    }


}
