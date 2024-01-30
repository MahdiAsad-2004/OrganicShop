namespace OrganicShop.Domain.Dtos.BankCardDtos
{
    public record CreateBankCardDto
    {
        public string Cvv2 { get; set; }
        public string Number { get; set; }
        public DateTime ExpireDate { get; set; }
        public string OwnerName { get; set; }
        public long UserId { get; set; }
    }



}
