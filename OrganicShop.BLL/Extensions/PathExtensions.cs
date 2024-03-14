﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.BLL.Extensions
{
    public static class PathExtensions
    {
        
        public static string CurrentDirectory = Directory.GetCurrentDirectory();

        public static string CategoryImage = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\media\\images\\category\\");

        public static string UserImage = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\media\\images\\user\\");

        public static string ProductImage = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\media\\images\\product\\");

    }
}
