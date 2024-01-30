using OrganicShop.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.Entities
{
    public class Address : EntityId<long>
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string PostCode { get; set; }
        public string Phone { get; set; }
        public long UserId { get; set; }



        public User User { get; set; }
        public ICollection<Order> Orders { get; set; }



    }
}
