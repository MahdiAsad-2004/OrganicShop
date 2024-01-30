using OrganicShop.Domain.Dtos.Base;

namespace OrganicShop.Domain.Dtos.ProductDtos
{
    public class FilterProductDto : BaseFilterDto<Entities.Product, long>
    {
        public string? Title { get; set; }
        public string? Barcode { get; set; }
        public int? MaxPrice { get; set; }
        public int? MinPrice { get; set; }
        public long? ProductId { get; set; }
        public int? CategoryId { get; set; }
    }


}
