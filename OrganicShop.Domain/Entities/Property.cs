using OrganicShop.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.Entities
{
    public class Property : EntityId<int>
    {
        public string Title { get; set; }
        public string Value { get; set; }
        public bool IsBase { get; set; }
        public int Priority { get; set; }
        public long? ProductId { get; set; }




        public Product? Product { get; set; }


    }
}
