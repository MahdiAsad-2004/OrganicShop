using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.Enums.EntityResults
{
    public enum EntityResult
    {
        Success = 1,

        MaxCreate = 2,

        EntityExist = 3,

        WrongPassword = 4,

        NotFound = 5,

        NoAccess = 6,

        Failed = 7,

    }
}
