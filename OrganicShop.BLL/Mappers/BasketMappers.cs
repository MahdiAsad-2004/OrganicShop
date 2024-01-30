using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Dtos.BaketDtos;

namespace OrganicShop.BLL.Mappers
{
    public static class BasketMappers
    {
        public static BasketListDto ToListDto(this Basket Basket)
        {
            return new BasketListDto
            {
                Id = Basket.Id,
                TotalPrice = Basket.TotalPrice,
                IsMain = Basket.IsMain,
                ProductsCount = Basket.CoProducts.Count,
            };
        }

        public static Basket ToModel(this CreateBasketDto create)
        {
            return new Basket()
            {
                UserId = create.UserId,
            };
        }

        public static Basket ToModel(this UpdateBasketDto update, Basket Basket)
        {
            return Basket;
        }









    }
}
