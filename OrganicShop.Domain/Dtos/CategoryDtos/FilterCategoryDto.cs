using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Enums;

namespace OrganicShop.Domain.Dtos.CategoryDtos
{
    public class FilterCategoryDto : BaseFilterDto<Entities.Category, int>
    {
        public string? Title { get; set; }
        public string? EnTitle { get; set; }
        public CategoryType? Type { get; set; }
    }




}
