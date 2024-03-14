using Microsoft.AspNetCore.Http;
using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums;

namespace OrganicShop.Domain.Dtos.CategoryDtos
{
    public class UpdateCategoryDto : BaseListDto<int>
    {
        public string Title { get; set; }
        public string IconClass { get; set; }
        public string IconColor { get; set; }
        public CategoryType Type { get; set; }
        public IFormFile ImageFile { get; set; }
        public string ImageName { get; set; }
        public int? ParentId { get; set; }

    }




}
