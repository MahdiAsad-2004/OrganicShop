using OrganicShop.Domain.Enums;
using OrganicShop.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace OrganicShop.Domain.Entities
{
    [DisplayName("دسته بندی")]
    public class Category : EntityId<int>
    {
        public string Title { get; set; }
        public string EnTitle { get; set; }
        public CategoryType Type { get; set; }
        public int? ParentId { get; set; }



        public Category? Parent { get; set; }
        public ICollection<Category>? Subs { get; set; }
        public ICollection<Product>? Products { get; set; }

    }
}
