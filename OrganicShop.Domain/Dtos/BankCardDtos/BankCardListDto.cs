using OrganicShop.Domain.Dtos.Base;

namespace OrganicShop.Domain.Dtos.BankCardDtos
{
    public class BankCardListDto : BaseDto<long>
    {
        public string Cvv2 { get; set; }
        public string Number { get; set; }
        public DateTime ExpireDate { get; set; }
        public string OwnerName { get; set; }
    }



}
