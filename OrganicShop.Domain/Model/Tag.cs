using OrganicShop.Domain.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.Model
{
    public class Tag : BaseEntity<int>
    {
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}
