using OrganicShop.Domain.Dtos.Base;

namespace OrganicShop.Domain.Dtos.TagDtos
{
    public class UpdateTagDto : BaseListDto<int>
    {
        public string Title { get; set; }
    }





}
