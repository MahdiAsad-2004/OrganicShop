using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.Entities.Base
{
    public class BaseEntity
    {
        public DateTime CreateDate { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsActive { get; set; }


        public BaseEntity()
        {
                
        }

        public BaseEntity(bool newEntity)
        {
            CreateDate = DateTime.Now;
            LastModified = DateTime.Now;
            IsActive = true;
        }



    }
}
