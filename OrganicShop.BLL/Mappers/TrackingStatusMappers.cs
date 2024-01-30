using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Dtos.TrackingStatusDtos;

namespace OrganicShop.BLL.Mappers
{
    public static class TrackingStatusMappers
    {
        public static TrackingStatusListDto ToListDto(this TrackingStatus TrackingStatus)
        {
            return new TrackingStatusListDto
            {
                Id = TrackingStatus.Id,
                DoneStatus = TrackingStatus.DoneStatus,
                DoneDate = TrackingStatus.DoneDate,
                Step = TrackingStatus.Step,
            };
        }

        public static TrackingStatus ToModel(this CreateTrackingStatusDto create)
        {
            return new TrackingStatus()
            {
                OrderId = create.OrderId,
            };
        }

        public static TrackingStatus ToModel(this UpdateTrackingStatusDto update, TrackingStatus TrackingStatus)
        {
            TrackingStatus.DoneStatus = update.DoneStatus;
            TrackingStatus.DoneDate = update.DoneDate;
            return TrackingStatus;
        }









    }
}
