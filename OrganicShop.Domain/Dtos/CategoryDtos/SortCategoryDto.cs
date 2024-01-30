using OrganicShop.Domain.Dtos.Base;

namespace OrganicShop.Domain.Dtos.CategoryDtos
{
    public class SortCategoryDto : BaseSortDto<Entities.Category, int>
    {
        public bool? Title { get; set; }
    }




}
