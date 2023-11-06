using OrganicShop.Domain.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.Model
{
    public class CoProduct : BaseEntity<long>
    {
        public int ProductId { get; set; }
        public int Count { get; set; }
        public int BuyPrice { get; set; }
        public Product Product { get; set; }
    }
}
