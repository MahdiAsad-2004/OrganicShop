using Microsoft.AspNetCore.Http;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.BLL.Extensions
{
    public static class TextExtension
    {
        public static string ToText(this string text)
        {
            return text.Trim().ToLower();
        }




    }
}
