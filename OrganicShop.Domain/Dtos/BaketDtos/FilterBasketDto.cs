﻿using OrganicShop.Domain.Dtos.Base;

namespace OrganicShop.Domain.Dtos.BaketDtos
{
    public class FilterBasketDto : BaseFilterDto<Entities.Basket, long>
    {
        public long? UserId { get; set; }
    }



}
