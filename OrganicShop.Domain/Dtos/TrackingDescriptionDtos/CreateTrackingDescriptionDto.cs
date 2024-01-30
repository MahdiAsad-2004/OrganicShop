namespace OrganicShop.Domain.Dtos.TrackingDescriptionDtos
{
    public record CreateTrackingDescriptionDto
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public long OrderId { get; set; }

    }





}
