using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Enums;

namespace OrganicShop.Domain.Dtos.TagDtos
{
    // True for ascending ,,,, False for descending
    public class SortTagDto : BaseSortDto<Entities.Tag, int>
    {
        public SortOrder? Title { get; set; } = null;
    }





}
