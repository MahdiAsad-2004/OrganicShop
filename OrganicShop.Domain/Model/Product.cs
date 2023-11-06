using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrganicShop.Domain.Model.Base;

namespace OrganicShop.Domain.Model
{
    public class Product : BaseEntity<long>
    {
        public int Price { get; set; }
        public string Title { get; set; }
        public int Stock { get; set; }
        public int Sold { get; set; }
        public ICollection<Image>? Images { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<Discount> Discount { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public ICollection<Property> Properties { get; set; }
    }
}
