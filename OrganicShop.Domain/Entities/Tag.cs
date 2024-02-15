using OrganicShop.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.Entities
{
    [DisplayName("برچسب")]
    public class Tag : EntityId<int>
    {
        public string Title { get; set; }


        public ICollection<Product>? Products { get; set; }

    }
}
