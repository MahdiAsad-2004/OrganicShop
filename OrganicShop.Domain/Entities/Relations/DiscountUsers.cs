using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Enums;

namespace OrganicShop.Domain.Entities.Relations
{
    public class DiscountUsers : EntityId<int>
    {
        public int DiscountId { get; set; }
        public long UserId { get; set; }
        
        
        public Discount Discount { get; set; }
        public User User { get; set; }
    }
}
