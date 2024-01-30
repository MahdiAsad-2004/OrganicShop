using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.Enums.EntityResults
{
    public enum EntityResultUpdate
    {
        success = 1,

        EntityExist = 2,

        EmailExist = 3,

        NotFound = 4,
        
        WrongPassword = 5,
        
        NoAccess = 6,

        Failed = 7,


    }
}
