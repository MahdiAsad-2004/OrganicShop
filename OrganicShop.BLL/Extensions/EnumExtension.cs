using Microsoft.AspNetCore.Http;
using OrganicShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.BLL.Extensions
{
    public static class EnumExtension
    {

        public static MyEnum[] GetArray<MyEnum>()
        {
            if (typeof(MyEnum).IsEnum == false)
                throw new Exception("Type is not enum");
            return Enum.GetValues(typeof(MyEnum)) as MyEnum[];
        }

    }
}
