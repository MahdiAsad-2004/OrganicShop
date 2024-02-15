
using Microsoft.AspNetCore.Http;
using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Dtos.DiscountDtos;
using OrganicShop.Domain.Entities;

namespace OrganicShop.Domain.Dtos.ProductDtos
{
    public class CreateProductDto : BaseDto
    {
        public string Title { get; set; }
        public string Barcode { get; set; }
        public int Stock { get; set; }
        public int Price { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public IFormFile MainImage { get; set; }
        public IEnumerable<IFormFile> PictureFiles { get; set; }
        public IEnumerable<string> Tags { get; set; }
        public Dictionary<string, string> Properties { get; set; }
        public int? UpdatedPrice { get; set; }
        public int? DiscountCount { get; set; }
    }


}
