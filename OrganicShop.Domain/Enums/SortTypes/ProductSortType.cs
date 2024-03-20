﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.Enums
{
    public enum ProductSortType
    {
        None,

        Newest,

        LatestChange,

        Oldest,


        Title,

        TitleDesc,

        Stock,

        StockDesc,

        Price,

        PriceDesc,

        SoldCount,

        SoldCountDesc,

        Discount,

        DiscountDesc,

    }
}
