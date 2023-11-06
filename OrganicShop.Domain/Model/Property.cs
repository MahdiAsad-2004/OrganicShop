﻿using OrganicShop.Domain.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.Model
{
    public class Property : BaseEntity<long>
    {
        public string Title { get; set; }
        public string Value { get; set; }
        public ICollection<Product> Products { get; set; }


    }
}
