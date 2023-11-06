using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.Model.Base
{
    public class BaseEntity<T> where T : struct
    {
        public T Id { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreaeteDate { get; set; }
        public DateTime DelteDate { get; set; }
        public DateTime LastModified { get; set; }

    }
}
