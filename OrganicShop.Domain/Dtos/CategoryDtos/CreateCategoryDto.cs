using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Enums;

namespace OrganicShop.Domain.Dtos.CategoryDtos
{
    public class CreateCategoryDto : BaseDto
    {
        public string Title { get; set; }
        public string EnTitle { get; set; }
        public CategoryType Type { get; set; }
        public int? ParentId { get; set; }
    }




}
