using OrganicShop.Domain.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.Model
{
    public class Discount : BaseEntity<int>
    {
        public string Code { get; set; }
        public int Count { get; set; }
        public int? FixedValue { get; set; }
        public int? Percent { get; set; }


        public ICollection<Product>? Products { get; set; }
        public ICollection<User>? Users { get; set; }

    }
}
