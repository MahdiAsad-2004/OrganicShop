using OrganicShop.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.Entities
{
    [DisplayName("تصویر")]
    public class Picture : EntityId<long>
    { 
        public string Name { get; set; }
        public float SizeMB { get; set; }
        public long? ProductId { get; set; }


        public Product? Product { get; set; }

    }
}
