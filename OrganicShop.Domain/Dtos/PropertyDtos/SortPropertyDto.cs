using OrganicShop.Domain.Dtos.Base;

namespace OrganicShop.Domain.Dtos.PropertyDtos
{
    public class SortPropertyDto : BaseSortDto<Entities.Property, int>
    {
        public bool? Priority { get; set; }
    }



}
