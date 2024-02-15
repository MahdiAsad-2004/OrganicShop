using OrganicShop.Domain.Dtos.Base;

namespace OrganicShop.Domain.Dtos.CategoryDtos
{
    public class CategoryListDto : BaseListDto<int>
    {
        public string Title { get; set; }
        public string EnTitle { get; set; }
        public string Type { get; set; }
        public string ParentTitle { get; set; }
        public string ParentEnTitle { get; set; }
    }




}
