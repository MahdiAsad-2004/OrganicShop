using OrganicShop.Domain.Dtos.DiscountDtos;
using OrganicShop.Domain.Entities;

namespace OrganicShop.BLL.Mappers
{
    public static class DiscountMappers
    {
        public static DiscountListDto ToListDto(this Discount Discount)
        {
            return new DiscountListDto
            {
                Id = Discount.Id,
                IsDefault = Discount.IsDefault,
                Code = Discount.Code,
                Percent = Discount.Percent,
                FixedValue = Discount.FixedValue,
                Count = Discount.Count,
                CreateDate = Discount.BaseEntity.CreateDate,
                IsActive = Discount.BaseEntity.IsActive,
            };
        }

        public static Discount ToModel(this CreateDiscountDto create)
        {
            return new Discount()
            {
                IsDefault = create.IsDefault,
                Code = create.Code,
                Percent = create.Percent,
                FixedValue = create.FixedValue,
                Count = create.Count,
            };
        }

        public static Discount ToModel(this UpdateDiscountDto update, Discount Discount)
        {
            Discount.IsDefault = update.IsDefault;
            Discount.Code = update.Code;
            Discount.Percent = update.Percent;
            Discount.FixedValue = update.FixedValue;
            Discount.Count = update.Count;
            return Discount;
        }









    }
}
