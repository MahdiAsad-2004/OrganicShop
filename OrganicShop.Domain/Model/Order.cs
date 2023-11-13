using OrganicShop.Domain.Enum;
using OrganicShop.Domain.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.Model
{
    public class Order : BaseEntity<long>
    {
        public string TrackingCode { get; set; }
        public int? TotalPrice { get; set; }
        public long ReceiverId { get; set; }
        public long AddressId { get; set; }
        public DateTime DeliveryTime { get; set; }
        public DeliveryType DeliveryType { get; set; }



        public Address Address { get; set; }
        public User Receiver { get; set; }
        public ICollection<OrderStatus>? OrderStatuses { get; set; }
        public ICollection<OrderTrack>? OrderTracks { get; set; }
        public ICollection<CoProduct>? CoProducts { get; set; }
    }
}
