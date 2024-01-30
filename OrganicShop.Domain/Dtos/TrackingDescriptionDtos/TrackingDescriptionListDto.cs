﻿
using OrganicShop.Domain.Dtos.Base;

namespace OrganicShop.Domain.Dtos.TrackingDescriptionDtos
{
    public class TrackingDescriptionListDto : BaseDto<long>
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
    }





}
