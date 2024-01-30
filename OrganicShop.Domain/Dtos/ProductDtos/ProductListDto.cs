using OrganicShop.Domain.Dtos.Base;

namespace OrganicShop.Domain.Dtos.ProductDtos
{
    public class ProductListDto : BaseDto<long>
    {
        public string Title { get; set; }
        public int Stock { get; set; }
        public string Price { get; set; }
        public string UpdatedPrice { get; set; }
        public int SoldCount { get; set; }
        public string MainImage { get; set; }
        public string Barcode { get; set; }
    }


}
