using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Dtos.CoProductDtos;

namespace OrganicShop.BLL.Mappers
{
    public static class CoProductMappers
    {
        public static CoProductListDto ToListDto(this CoProduct CoProduct )
        {
            var coProductListDto = new CoProductListDto
            {
                Id = CoProduct.Id,
                Count = CoProduct.Count,
                BasketId = CoProduct.BasketId,
                Price = CoProduct.Product.Price,
                UpdatedPrice = CoProduct.Product.UpdatedPrice,
            };

            return coProductListDto;
        }

        public static CoProduct ToModel(this CoProductCreateDto create)
        {
            return new CoProduct()
            {
                ProductId = create.ProductId,
                BasketId = create.BasketId,
                Count = create.Count,
            };
        }

        public static CoProduct ToModel(this UpdateCoProductDto update, CoProduct CoProduct)
        {
            CoProduct.Count = update.Count;
            CoProduct.BasketId = update.BasketId;
            CoProduct.OrderId = update.OrderId;
            CoProduct.IsOrdered = update.IsOrdered;
            return CoProduct;
        }










    }
}
