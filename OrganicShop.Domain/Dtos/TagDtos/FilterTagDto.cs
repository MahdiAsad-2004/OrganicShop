using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.Dtos.TagDtos
{
    public class FilterTagDto : BaseFilterDto<Entities.Tag, int>
    {
        public string? Title { get; set; }
    }



}
