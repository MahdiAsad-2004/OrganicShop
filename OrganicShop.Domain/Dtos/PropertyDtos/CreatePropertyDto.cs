using OrganicShop.Domain.Dtos.Base;

namespace OrganicShop.Domain.Dtos.PropertyDtos
{
    public class CreatePropertyDto : BaseDto
    {
        public string Title { get; set; }
        public string Value { get; set; }
        public bool IsBase { get; set; }
        public int Priority { get; set; }
        public long? ProductId { get; set; }

    }



}
