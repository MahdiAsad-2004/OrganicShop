using OrganicShop.Domain.Dtos.Base;

namespace OrganicShop.Domain.Dtos.PropertyDtos
{
    public class FilterPropertyDto : BaseFilterDto<Entities.Property, int>
    {
        public bool? IsBase { get; set; }
        public long? ProductId { get; set; }
    }



}
