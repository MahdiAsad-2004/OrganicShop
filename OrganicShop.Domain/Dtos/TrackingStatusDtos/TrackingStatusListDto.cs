using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Enums;

namespace OrganicShop.Domain.Dtos.TrackingStatusDtos
{
    public class TrackingStatusListDto : BaseDto<long>
    {
        public DoneStatus DoneStatus { get; set; }
        public DateTime? DoneDate { get; set; }
        public OrderStep Step { get; set; }
    }


}
