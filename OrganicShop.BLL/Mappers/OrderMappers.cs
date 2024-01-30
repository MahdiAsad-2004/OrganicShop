using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Dtos.OrderDtos;

namespace OrganicShop.BLL.Mappers
{
    public static class OrderMappers
    {
        public static OrderListDto ToListDto(this Order Order)
        {
            return new OrderListDto
            {
                Id = Order.Id,
                TotalPrice = Order.TotalPrice,
                DeliveryDatePredicate = Order.DeliveryDatePredicate,
                DeliveryType = Order.DeliveryType,
                OrderStatus = Order.OrderStatus,
                TrackingCode = Order.TrackingCode,
                UserName = Order.Receiver.Name,
                UserPhoneNumber = Order.Receiver.PhoneNumber,
            };
        }

        public static Order ToModel(this CreateOrderDto create)
        {
            return new Order()
            {
                DeliveryType = create.DeliveryType,
                PaymentMethod = create.PaymentMethod,
                ReceiverId = create.UserId,
            };
        }

        public static Order ToModel(this UpdateOrderDto update, Order Order)
        {
            Order.OrderStatus = update.OrderStatus;
            Order.DeliveryDatePredicate = update.DeliveryDatePredicate;
            return Order;
        }









    }
}
