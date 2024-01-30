using Microsoft.Identity.Client;
using OrganicShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.BLL.Extensions
{
    public static class DiscountExtensions
    {
        public static int ApplyDiscount(this Discount discount , int price)
        {
            if(discount.FixedValue != null)
                return price - discount.FixedValue.Value;
            
            else if(discount.Percent != null)
                return price - (price * discount.Percent.Value / 100);

            throw new Exception("Discount is not valid !");
        }
    }
}
