using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums;

namespace OrganicShop.Domain.Dtos.PictureDtos
{
    // True for ascending ,,,, False for descending
    public class SortPictureDto : BaseSortDto<Entities.Picture, long>
    {
        public SortOrder? Name { get; set; } = null;
        public SortOrder? Size { get; set; } = null;
    }





}
