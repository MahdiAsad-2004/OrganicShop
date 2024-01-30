
using Microsoft.AspNetCore.Http;
using OrganicShop.Domain.Entities;

namespace OrganicShop.Domain.Dtos.ProductDtos
{
    public record CreateProductDto
    {
        public string Title { get; set; }
        public int Stock { get; set; }
        public int Price { get; set; }
        public string MainImage { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public IEnumerable<IFormFile> PictureFiles { get; set; }
        public IEnumerable<string> Tags { get; set; }
        public Dictionary<string, string> Properties { get; set; }
        public Discount Discount { get; set; } = new Discount { IsDefault = true };
    }


}
