using OrganicShop.BLL.Extensions;
using OrganicShop.Domain.Dtos.BankCardDtos;
using OrganicShop.Domain.Entities;

namespace OrganicShop.BLL.Mappers
{
    public static class BankCardMappers
    {
        public static BankCardListDto ToListDto(this BankCard BankCard)
        {
            return new BankCardListDto
            {
                Id = BankCard.Id,
                Cvv2 = BankCard.Cvv2,
                Number = BankCard.Number,
                OwnerName = BankCard.OwnerName,
                ExpireDate = BankCard.ExpireDate,
            };
        }

        public static BankCard ToModel(this CreateBankCardDto create)
        {
            return new BankCard()
            {
                UserId = create.UserId,
                Cvv2 = create.Cvv2.ToText(),
                Number = create.Number.ToText(),
                OwnerName = create.OwnerName.ToText(),
                ExpireDate = create.ExpireDate,
            };
        }

        public static BankCard ToModel(this UpdateBankCardDto update, BankCard BankCard)
        {
            BankCard.Cvv2 = update.Cvv2.ToText();
            BankCard.Number = update.Number.ToText();
            BankCard.OwnerName = update.OwnerName.ToText();
            BankCard.ExpireDate = update.ExpireDate;
            return BankCard;
        }









    }
}
