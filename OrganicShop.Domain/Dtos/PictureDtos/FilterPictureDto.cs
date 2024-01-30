using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Entities;

namespace OrganicShop.Domain.Dtos.PictureDtos
{
    public class FilterPictureDto : BaseFilterDto<Entities.Picture, long>
    {
        public string? Name { get; set; }
        public int? Size { get; set; }
    }





}
