using OrganicShop.Domain.Dtos.Base;

namespace OrganicShop.Domain.Dtos.PictureDtos
{
    public class PictureListDto : BaseListDto<long>
    {
        public string Name { get; set; }
        public int SizeMb { get; set; }
    }





}
