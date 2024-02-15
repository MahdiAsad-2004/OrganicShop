using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Dtos.ProductDtos;
using OrganicShop.BLL.Extensions;

namespace OrganicShop.BLL.Mappers
{
    public static class ProductMappers
    {
        public static ProductListDto ToListDto(this Product Product)
        {
            return new ProductListDto
            {
                Id = Product.Id,
                Title = Product.Title,
                Stock = Product.Stock,
                Price = Product.Price.ToString(),
                UpdatedPrice = Product.UpdatedPrice == null ? Product.Price.ToString() : Product.UpdatedPrice.ToString(),
                SoldCount = Product.SoldCount,
                MainImage = Product.MainImage,
                Barcode = Product.Barcode,
                CategoryTitle = Product.Category.Title,
                IsActive = Product.BaseEntity.IsActive,
            };
        }

        public static Product ToModel(this CreateProductDto create)
        {
            return new Product()
            {
                Title = create.Title.Trim(),
                Stock = create.Stock,
                Price = create.Stock,
                ShortDescription = create.ShortDescription.Trim(),
                Description = create.Description,
                MainImage = create.MainImage.FileName.ToText(),
            };
        }

        public static Product ToModel(this UpdateProductDto update, Product Product)
        {
            Product.Title = update.Title.Trim();
            Product.Stock = update.Stock;
            Product.Price = update.Price;
            Product.ShortDescription = update.ShortDescription.Trim();
            Product.Description = update.Description;
            Product.MainImage = update.MainImage.FileName.Trim();
            Product.BaseEntity.IsActive = update.IsActive;
            return Product;
        }









    }
}
