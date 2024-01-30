using OrganicShop.Domain.Dtos.TrackingDescriptionDtos;
using OrganicShop.Domain.Entities;

namespace OrganicShop.BLL.Mappers
{
    public static class TrackingDescriptionMappers
    {
        public static TrackingDescriptionListDto ToListDto(this TrackingDescription TrackingDescription)
        {
            return new TrackingDescriptionListDto
            {
                Id = TrackingDescription.Id,
                Title = TrackingDescription.Title,
                Date = TrackingDescription.Date,
                Location = TrackingDescription.Location,
            };
        }

        public static TrackingDescription ToModel(this CreateTrackingDescriptionDto create)
        {
            return new TrackingDescription()
            {
                Title = create.Title,
                Date = create.Date,
                Location = create.Location,
                OrderId = create.OrderId,
            };
        }

        public static TrackingDescription ToModel(this UpdateTrackingDescriptionDto update, TrackingDescription TrackingDescription)
        {
            TrackingDescription.Title = update.Title;
            TrackingDescription.Date = update.Date;
            TrackingDescription.Location = update.Location;
            TrackingDescription.OrderId = update.OrderId;
            return TrackingDescription;
        }









    }
}
