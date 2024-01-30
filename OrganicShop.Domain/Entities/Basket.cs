using OrganicShop.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.Entities
{
    public class Basket : EntityId<long>
    {
        public long UserId { get; set; }
        public int TotalPrice { get; set; }
        public bool IsMain { get; set; }


        public User User { get; set; }
        public ICollection<CoProduct> CoProducts { get; set; }


    }
}
