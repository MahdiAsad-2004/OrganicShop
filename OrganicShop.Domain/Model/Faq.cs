using OrganicShop.Domain.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.Model
{
    public class Faq : BaseEntity<byte>
    {
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
