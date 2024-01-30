using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.Dtos.CategoryDtos
{
    public class UpdateCategoryDto : BaseDto<int>
    {
        public string Title { get; set; }
        public string EnTitle { get; set; }
        public CategoryType Type { get; set; }
        public int? ParentId { get; set; }

    }




}
