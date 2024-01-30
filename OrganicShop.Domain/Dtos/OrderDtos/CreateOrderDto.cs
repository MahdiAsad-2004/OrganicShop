using OrganicShop.Domain.Enums;

namespace OrganicShop.Domain.Dtos.OrderDtos
{
    public record CreateOrderDto
    {
        public DeliveryType DeliveryType { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public long UserId { get; set; }
        public long AddressId { get; set; }
        public long BasketId { get; set; }
    }




}
