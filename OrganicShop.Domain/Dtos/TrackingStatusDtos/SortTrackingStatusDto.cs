using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Enums;

namespace OrganicShop.Domain.Dtos.TrackingStatusDtos
{
    // True for ascending ,,,, False for descending
    public class SortTrackingStatusDto : BaseSortDto<Entities.TrackingStatus, long>
    {
        public SortOrder? Step { get; set; } = null;
    }

}
