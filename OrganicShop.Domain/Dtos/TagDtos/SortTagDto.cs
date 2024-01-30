using OrganicShop.Domain.Dtos.Base;

namespace OrganicShop.Domain.Dtos.TagDtos
{
    // True for ascending ,,,, False for descending
    public class SortTagDto : BaseSortDto<Entities.Tag, int>
    {
        public bool? Title { get; set; }
    }





}
