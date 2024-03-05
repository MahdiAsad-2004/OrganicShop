﻿
using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Entities;

namespace OrganicShop.Domain.Dtos.TrackingDescriptionDtos
{
    // True for ascending ,,,, False for descending
    public class SortTrackingDescriptionDto : BaseSortDto<TrackingDescription, long>
    {
        public bool? Title { get; set; }
        public bool? Date { get; set; }
    }





}