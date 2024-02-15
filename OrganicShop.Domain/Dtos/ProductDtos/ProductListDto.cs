using OrganicShop.Domain.Dtos.Base;

namespace OrganicShop.Domain.Dtos.ProductDtos
{
    public class ProductListDto : BaseListDto<long>
    {
        public string Title { get; set; }
        public int Stock { get; set; }
        public string Price { get; set; }
        public string UpdatedPrice { get; set; }
        public int SoldCount { get; set; }
        public string MainImage { get; set; }
        public string Barcode { get; set; }
        public string CategoryTitle { get; set; }
        public bool IsActive { get; set; }

    }


}
