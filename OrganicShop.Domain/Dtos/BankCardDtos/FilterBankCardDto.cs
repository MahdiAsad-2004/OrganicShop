using OrganicShop.Domain.Dtos.Base;

namespace OrganicShop.Domain.Dtos.BankCardDtos
{
    public class FilterBankCardDto : BaseFilterDto<Entities.BankCard, long>
    {
        public long? UserId { get; set; }
    }



}
