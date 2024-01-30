namespace OrganicShop.Domain.Dtos.CoProductDtos
{
    public record CoProductCreateDto
    {
        public long ProductId { get; set; }
        public long BasketId { get; set; }
        public int Count { get; set; }
    }

}
