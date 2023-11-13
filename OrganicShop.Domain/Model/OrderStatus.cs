using OrganicShop.Domain.Enum;
using OrganicShop.Domain.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.Model
{
    public class OrderStatus : BaseEntity<long>
    {
        public bool IsDone { get; set; }
        public DateTime? DoneDate { get; set; }
        public Enum.OrderStatus Status { get; set; }
        public long OrderId { get; set; }


        public Order Order { get; set; }
    }
}
