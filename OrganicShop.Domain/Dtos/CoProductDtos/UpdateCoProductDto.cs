using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.Dtos.CoProductDtos
{
    public class UpdateCoProductDto : BaseListDto<long>
    {
        public int Count { get; set; }
        public long? BasketId { get; set; }
        public long? OrderId { get; set; }
        public bool IsOrdered { get; set; }

    }

}
