using OrganicShop.Domain.Dtos.Base;

namespace OrganicShop.Domain.Dtos.PropertyDtos
{
    public class CreatePropertyDto : BaseDto
    {
        public string Title { get; set; }
        public int Priority { get; set; }

    }



}
