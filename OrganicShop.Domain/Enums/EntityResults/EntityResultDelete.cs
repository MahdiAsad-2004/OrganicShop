using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.Enums.EntityResults
{
    public enum EntityResultDelete
    {
        success = 1,

        NotFound = 2,
        
        NoAccess = 3,
    }
}
