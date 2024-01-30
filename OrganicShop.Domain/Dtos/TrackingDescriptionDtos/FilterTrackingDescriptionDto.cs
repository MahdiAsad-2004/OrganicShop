using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums;

namespace OrganicShop.Domain.Dtos.TrackingDescriptionDtos
{
    public class FilterTrackingDescriptionDto : BaseFilterDto<TrackingDescription, long>
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public long? OrderId { get; set; }
    }





}
