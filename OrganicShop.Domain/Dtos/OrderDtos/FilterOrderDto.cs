using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Enums;

namespace OrganicShop.Domain.Dtos.OrderDtos
{
    public class FilterOrderDto : BaseFilterDto<Entities.Order, long>
    {
        public long UserId { get; set; }
        public OrderStatus? OrderStatus { get; set; }
        public DeliveryType? DeliveryType { get; set; }
        public string? UserPhoneNumber { get; set; }
        public string? TrackingCode { get; set; }
    }




}
