using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.Enums
{
    public enum BaseSortType
    {
        None = 0,

        Newest = 1,

        LatestChange = 2,

        Oldest = 3,

        LatestDelete = 4,
    }
}
