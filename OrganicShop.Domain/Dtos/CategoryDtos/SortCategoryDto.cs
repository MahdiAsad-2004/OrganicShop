using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Enums;

namespace OrganicShop.Domain.Dtos.CategoryDtos
{
    public class SortCategoryDto : BaseSortDto<Entities.Category, int>
    {
        public SortOrder? Title { get; set; } = null;
    }




}
