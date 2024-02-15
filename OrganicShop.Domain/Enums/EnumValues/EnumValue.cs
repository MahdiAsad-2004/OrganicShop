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
    }
}
