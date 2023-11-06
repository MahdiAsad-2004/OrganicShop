using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.Model
{
    public class Image
    {
        public string Name { get; set; }
        public float SizeMB { get; set; }
        public long? UserId { get; set; }
        public long? ProductId { get; set; }
        public User? User { get; set; }
        public Product? Product { get; set; }

    }
}
