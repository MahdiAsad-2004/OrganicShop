﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.Enums
{
    public enum CoProductSortType
    {
        None,

        Newest,

        LatestChange,

        Oldest,


        Price,

        PriceDesc,

        Count,

        CountDesc,
    }
}
