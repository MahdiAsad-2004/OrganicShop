using OrganicShop.Domain.Enums;

namespace OrganicShop.Domain.Dtos.CategoryDtos
{
    public record CreateCategoryDto
    {
        public string Title { get; set; }
        public string EnTitle { get; set; }
        public CategoryType Type { get; set; }
        public int? ParentId { get; set; }
    }




}
