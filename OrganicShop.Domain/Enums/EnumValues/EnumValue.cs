﻿using OrganicShop.Domain.Enums.SortTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.Enums.EnumValues
{
    public static class EnumValue
    {
        public static string ToStringValue(this CategoryType categoryType)
        {
            switch (categoryType)
            {
                case CategoryType.All:
                    return "سایت";

                case CategoryType.Product:
                    return "محصولات";

                case CategoryType.Article:
                    return "مطالب";

                default:
                    throw new Exception("Enum value not found");
            }
        }

        public static string ToStringValue(this CommentStatus commentStatus)
        {
            switch (commentStatus)
            {
                case CommentStatus.Unread:
                    return "بررسی نشده";

                case CommentStatus.NotAccepted:
                    return "رد شده";

                case CommentStatus.Accepted:
                    return "تایید شده";

                default:
                    throw new Exception("Enum value not found");
            }


        }

        public static string ToStringValue(this IsActiveFilter activeFilter)
        {
            switch (activeFilter)
            {
                case IsActiveFilter.All:
                    return "همه";

                case IsActiveFilter.Active:
                    return "فعال";

                case IsActiveFilter.NotActive:
                    return "غیر فعال";

                default:
                    throw new Exception("Enum value not found");
            }
        }

        public static string ToStringValue(this Role role)
        {
            switch (role)
            {
                case Role.Manager:
                    return "مدیر";

                case Role.Admin:
                    return "ادمین";

                case Role.Customer:
                    return "مشتری";
                default:
                    throw new Exception("Enum value not found");

            }
        }

        public static string ToStringValue(this BaseSortType sortType)
        {
            switch (sortType)
            {
                case BaseSortType.None:
                    return "بدون ترتیب";

                case BaseSortType.Newest:
                    return "جدیدترین";

                case BaseSortType.LatestChange:
                    return "آخرین تغییر";

                case BaseSortType.Oldest:
                    return "قدیمی ترین";

                default:
                    throw new Exception("Enum value not found");
            }
        }

        public static string ToStringValue(this BasketSortType sortType)
        {
            switch (sortType)
            {
                case BasketSortType.None:
                    return "بدون ترتیب";

                case BasketSortType.Newest:
                    return "جدیدترین";

                case BasketSortType.LatestChange:
                    return "آخرین تغییر";

                case BasketSortType.Oldest:
                    return "قدیمی ترین";

                case BasketSortType.TotalPrice:
                    return "ارزش کمترین";

                case BasketSortType.TotalPriceDesc:
                    return "ارزش بیشترین";

                default:
                    throw new Exception("Enum value not found");
            }
        }

        public static string ToStringValue(this CategorySortType sortType)
        {
            switch (sortType)
            {
                case CategorySortType.None:
                    return "بدون ترتیب";

                case CategorySortType.Newest:
                    return "جدیدترین";

                case CategorySortType.LatestChange:
                    return "آخرین تغییر";

                case CategorySortType.Oldest:
                    return "قدیمی ترین";

                case CategorySortType.Title:
                    return "عنوان صعودی";

                case CategorySortType.TitleDesc:
                    return "عنوان نزولی";

                default:
                    throw new Exception("Enum value not found");
            }
        }


        public static string ToStringValue(this CommentSortType sortType)
        {
            switch (sortType)
            {
                case CommentSortType.None:
                    return "بدون ترتیب";

                case CommentSortType.Newest:
                    return "جدیدترین";

                case CommentSortType.LatestChange:
                    return "آخرین تغییر";

                case CommentSortType.Oldest:
                    return "قدیمی ترین";

                case CommentSortType.Rate:
                    return "امتیاز کمترین";

                case CommentSortType.RateDesc:
                    return "امتیاز بیشترین";

                default:
                    throw new Exception("Enum value not found");
            }
        }


        public static string ToStringValue(this CoProductSortType sortType)
        {
            switch (sortType)
            {
                case CoProductSortType.None:
                    return "بدون ترتیب";

                case CoProductSortType.Newest:
                    return "جدیدترین";

                case CoProductSortType.LatestChange:
                    return "آخرین تغییر";

                case CoProductSortType.Oldest:
                    return "قدیمی ترین";

                case CoProductSortType.Price:
                    return "قیمت کمترین";

                case CoProductSortType.PriceDesc:
                    return "قیمت بیشترین";

                case CoProductSortType.Count:
                    return "تعداد کمترین";

                case CoProductSortType.CountDesc:
                    return "تعداد بیشترین";

                default:
                    throw new Exception("Enum value not found");
            }
        }


        public static string ToStringValue(this DiscountSortType sortType)
        {
            switch (sortType)
            {
                case DiscountSortType.None:
                    return "بدون ترتیب";

                case DiscountSortType.Newest:
                    return "جدیدترین";

                case DiscountSortType.LatestChange:
                    return "آخرین تغییر";

                case DiscountSortType.Oldest:
                    return "قدیمی ترین";

                case DiscountSortType.Percent:
                    return "درصد کمترین";

                case DiscountSortType.PercentDesc:
                    return "درصد بیشترین";

                case DiscountSortType.FixedValue:
                    return "مقدار ثابت کمترین";

                case DiscountSortType.FixedValueDesc:
                    return "مقدار ثابت بیشترین";

                case DiscountSortType.Count:
                    return "تعداد کمترین";

                case DiscountSortType.CountDesc:
                    return "تعداد بیشترین";

                default:
                    throw new Exception("Enum value not found");
            }
        }


        public static string ToStringValue(this PermissionSortType sortType)
        {
            switch (sortType)
            {
                case PermissionSortType.None:
                    return "بدون ترتیب";

                case PermissionSortType.Newest:
                    return "جدیدترین";

                case PermissionSortType.LatestChange:
                    return "آخرین تغییر";

                case PermissionSortType.Oldest:
                    return "قدیمی ترین";

                case PermissionSortType.Title:
                    return "عنوان کمترین";

                case PermissionSortType.TitleDesc:
                    return "عنوان بیشترین";

                case PermissionSortType.EnTitle:
                    return "عنوان انگلیسی کمترین";

                case PermissionSortType.EnTitleDesc:
                    return "عنوان انگلیسی بیشترین";

                default:
                    throw new Exception("Enum value not found");
            }
        }


        public static string ToStringValue(this PictureSortType sortType)
        {
            switch (sortType)
            {
                case PictureSortType.None:
                    return "بدون ترتیب";

                case PictureSortType.Newest:
                    return "جدیدترین";

                case PictureSortType.LatestChange:
                    return "آخرین تغییر";

                case PictureSortType.Oldest:
                    return "قدیمی ترین";

                case PictureSortType.Size:
                    return "حجم کمترین";

                case PictureSortType.SizeDesc:
                    return "حجم بیشترین";

                default:
                    throw new Exception("Enum value not found");
            }
        }


        public static string ToStringValue(this ProductSortType sortType)
        {
            switch (sortType)
            {
                case ProductSortType.None:
                    return "بدون ترتیب";

                case ProductSortType.Newest:
                    return "جدیدترین";

                case ProductSortType.LatestChange:
                    return "آخرین تغییر";

                case ProductSortType.Oldest:
                    return "قدیمی ترین";

                case ProductSortType.Price:
                    return "قیمت کمترین";

                case ProductSortType.PriceDesc:
                    return "قیمت بیشترین";

                case ProductSortType.Title:
                    return "عنوان صعودی";

                case ProductSortType.TitleDesc:
                    return "عنوان نزولی";

                case ProductSortType.SoldCount:
                    return "فروش کمترین";

                case ProductSortType.SoldCountDesc:
                    return "فروش بیشترین";

                case ProductSortType.Stock:
                    return "موجودی کمترین";

                case ProductSortType.StockDesc:
                    return "موجودی بیشترین";

                case ProductSortType.Discount:
                    return "تخفیف کمترین";

                case ProductSortType.DiscountDesc:
                    return "تخفیف بیشترین";

                default:
                    throw new Exception("Enum value not found");
            }
        }


        public static string ToStringValue(this TagSortType sortType)
        {
            switch (sortType)
            {
                case TagSortType.None:
                    return "بدون ترتیب";

                case TagSortType.Newest:
                    return "جدیدترین";

                case TagSortType.LatestChange:
                    return "آخرین تغییر";

                case TagSortType.Oldest:
                    return "قدیمی ترین";

                case TagSortType.Title:
                    return "عنوان صعودی";

                case TagSortType.TitleDesc:
                    return "عنوان نزولی";

                default:
                    throw new Exception("Enum value not found");
            }


        }


        public static string ToStringValue(this TrackingDescriptionSortType sortType)
        {
            switch (sortType)
            {
                case TrackingDescriptionSortType.None:
                    return "بدون ترتیب";

                case TrackingDescriptionSortType.Newest:
                    return "جدیدترین";

                case TrackingDescriptionSortType.LatestChange:
                    return "آخرین تغییر";

                case TrackingDescriptionSortType.Oldest:
                    return "قدیمی ترین";

                case TrackingDescriptionSortType.Title:
                    return "عنوان صعودی";

                case TrackingDescriptionSortType.TitleDesc:
                    return "عنوان نزولی";

                default:
                    throw new Exception("Enum value not found");
            }
        }


        public static string ToStringValue(this UserSortType sortType)
        {
            switch (sortType)
            {
                case UserSortType.None:
                    return "بدون ترتیب";

                case UserSortType.Newest:
                    return "جدیدترین";

                case UserSortType.LatestChange:
                    return "آخرین تغییر";

                case UserSortType.Oldest:
                    return "قدیمی ترین";

                case UserSortType.Name:
                    return "نام صعودی";

                case UserSortType.NameDesc:
                    return "نام نزولی";

                case UserSortType.Email:
                    return "ایمیل صعودی";

                case UserSortType.EmailDesc:
                    return "ایمیل نزولی";

                case UserSortType.PhoneNumber:
                    return "شماره همراه صعودی";

                case UserSortType.PhoneNumberDesc:
                    return "شماره همراه نزولی";

                default:
                    throw new Exception("Enum value not found");
            }
        }











    }
}
