using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.Enums.EntityResults
{
    public enum EntityResultCreate
    {
        success = 1,
        
        EmailExist = 2,

        PhoneNumberExist = 3,
        
        MaxCreate = 4,
        
        EntityExist = 5,
        
        NotFound = 6,

        Failed = 7,

    }
}
