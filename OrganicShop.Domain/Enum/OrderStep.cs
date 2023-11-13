using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.Enum
{
    public enum OrderStep
    {
        SubmitOrder = 0, DeliveredToPost = 1,Transporting = 2 , DeliveredToCustomer = 3
    }
}
