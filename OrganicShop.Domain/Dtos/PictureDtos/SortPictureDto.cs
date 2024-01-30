using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Entities;

namespace OrganicShop.Domain.Dtos.PictureDtos
{
    // True for ascending ,,,, False for descending
    public class SortPictureDto : BaseSortDto<Entities.Picture, long>
    {
        public bool? Name { get; set; }
        public bool? Size { get; set; }
    }





}
