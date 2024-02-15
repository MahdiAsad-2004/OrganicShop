using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Entities.Relations;

namespace OrganicShop.Domain.Entities
{
    [DisplayName("محصول")]
    public class Product : EntityId<long>
    {
        public int Price { get; set; }
        public int? UpdatedPrice { get; set; }
        public string Title { get; set; }
        public int Stock { get; set; }
        public int SoldCount { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string MainImage { get; set; }
        public string Barcode { get; set; }
        public int CategoryId { get; set; }





        public Category Category { get; set; }
        public ICollection<Picture>? Pictures { get; set; }
        public ICollection<DiscountProducts>? DiscountProducts { get; set; }
        public ICollection<CoProduct>? CoProducts { get; set; }
        public ICollection<Tag>? Tags { get; set; }
        public ICollection<Property>? Properties { get; set; }
    }
}
