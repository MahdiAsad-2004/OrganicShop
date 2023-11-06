using OrganicShop.Domain.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.Model
{
    public class OrderDescription : BaseEntity<long>
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public long OrderId { get; set; }
        public Order Order { get; set; }
    }

}
