﻿using OrganicShop.Domain.Dtos.Base;

namespace OrganicShop.Domain.Dtos.PictureDtos
{
    public class PictureListDto : BaseListDto<long>
    {
        public string Name { get; set; }
        public float SizeMB { get; set; }
        public long? ProductId { get; set; }
        public long? UserPictureId { get; set; }
        public int? CategoryPictureId { get; set; }

    }





}
