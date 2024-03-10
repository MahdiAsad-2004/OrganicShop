
using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums;

namespace OrganicShop.Domain.Dtos.TrackingDescriptionDtos
{
    // True for ascending ,,,, False for descending
    public class SortTrackingDescriptionDto : BaseSortDto<TrackingDescription, long>
    {
        public SortOrder? Title { get; set; } = null;
        public SortOrder? Date { get; set; } = null;
    }





}
