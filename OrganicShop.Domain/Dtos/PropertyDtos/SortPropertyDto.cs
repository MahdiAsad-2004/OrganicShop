using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Enums;

namespace OrganicShop.Domain.Dtos.PropertyDtos
{
    public class SortPropertyDto : BaseSortDto<Entities.Property, int>
    {
        public SortOrder? Priority { get; set; }
    }



}
