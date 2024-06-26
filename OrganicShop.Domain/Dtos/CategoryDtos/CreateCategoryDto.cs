﻿using Microsoft.AspNetCore.Http;
using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using OrganicShop.Mvc.ValidationsAttributes;

namespace OrganicShop.Domain.Dtos.CategoryDtos
{
    public class CreateCategoryDto : BaseDto
    {
        [DisplayName("عنوان")]
        [Required(ErrorMessage = "{0} ضروری است")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "{0} باید حداقل {2} و حداکثر {1} حرف داشته باشد")]
        public string Title { get; set; }


        [DisplayName("مشخصات آیکن")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "{0} باید حداقل {2} و حداکثر {1} حرف داشته باشد")]
        public string? IconClass { get; set; }

        [DisplayName("رنگ آیکن")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "{0} باید حداقل {2} و حداکثر {1} حرف داشته باشد")]
        public string? IconColor { get; set; }

        [DisplayName("نوع دسته")]
        [Required(ErrorMessage = "{0} ضروری است")]
        public CategoryType Type { get; set; }

        [DisplayName("تصویر دسته")]
        [Required(ErrorMessage = "{0} ضروری است")]
        [FileFormat(new string[] { "jpg","png","jpeg" })]
        public IFormFile ImageFile { get; set; }

        [DisplayName("سر دسته")]
        [Range(0,1000,ErrorMessage = "{0} معتبر نیست")]
        public int? ParentId { get; set; }
    }




}
