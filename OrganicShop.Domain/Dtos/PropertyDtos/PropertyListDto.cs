using OrganicShop.Domain.Dtos.Base;

namespace OrganicShop.Domain.Dtos.PropertyDtos
{
    public class PropertyListDto : BaseDto<int>
    {
        public string Title { get; set; }
        public string Value { get; set; }
        public int Priority { get; set; }
    }



}
