using OrganicShop.Domain.Enum;
using OrganicShop.Domain.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.Model
{
    public class Category : BaseEntity<int>
    {
        public string Name { get; set; }
        public string EnName { get; set; }
        public int Priority { get; set; }
        public CategoryType Type { get; set; }
        public int? CategoryId { get; set; }
        public ICollection<Category> Subs { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}
