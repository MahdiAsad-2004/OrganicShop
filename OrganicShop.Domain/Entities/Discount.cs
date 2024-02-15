using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Entities.Relations;
using OrganicShop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.Entities
{
    [DisplayName("تخفیف")]
    public class Discount : EntityId<int>
    {
        public bool IsDefault { get; set; } 
        public string? Code { get; set; }
        public int? Count { get; set; }
        public int? FixedValue { get; set; }
        public int? Percent { get; set; }



        public ICollection<DiscountProducts> DiscountProducts { get; set; }
        public ICollection<DiscountUsers> DiscountUsers { get; set; }

    }
}
