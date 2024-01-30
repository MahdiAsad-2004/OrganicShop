using OrganicShop.Domain.Dtos.Base;

namespace OrganicShop.Domain.Dtos.TrackingStatusDtos
{
    // True for ascending ,,,, False for descending
    public class SortTrackingStatusDto : BaseSortDto<Entities.TrackingStatus, long>
    {
        public bool Step { get; set; }
    }

}
