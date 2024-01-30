﻿using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.Dtos.TrackingStatusDtos
{
    public class FilterTrackingStatusDto : BaseFilterDto<Entities.TrackingStatus, long>
    {
        public DoneStatus? DoneStatus { get; set; }
    }

}
