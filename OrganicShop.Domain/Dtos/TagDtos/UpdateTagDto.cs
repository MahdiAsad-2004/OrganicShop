using OrganicShop.Domain.Dtos.Base;

namespace OrganicShop.Domain.Dtos.TagDtos
{
    public class UpdateTagDto : BaseDto<int>
    {
        public string Title { get; set; }
    }





}
