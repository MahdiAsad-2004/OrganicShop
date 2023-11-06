using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.Enum
{
    public enum OrderStatus
    {
        Processing = 0, Packing = 1, DeliveredToPost,Transporting = 2 , DeliveredToCustomer = 3
    }
}
