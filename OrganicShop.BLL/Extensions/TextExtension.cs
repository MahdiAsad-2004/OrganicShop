using MD.PersianDateTime;
using System.Globalization;


namespace OrganicShop.BLL.Extensions
{
    public static class TextExtension
    {
        public static string ToText(this string text)
        {
            return text.Trim().ToLower();
        }


        public static string ToToman(this string price)
        {
            char[] priceArray = price.ToCharArray();
            string toman = string.Empty;
            for (int i = 0; i < priceArray.Length; i++)
            {
                toman += priceArray[i];
                if (i == priceArray.Length - 4 || i == priceArray.Length - 7 || i == priceArray.Length - 10 || i == priceArray.Length - 13 || i == priceArray.Length - 16)
                {
                    toman += ",";
                }
            }
            return $"{toman} تومان";
        }


        public static string ToToman(this int price)
        {
            char[] priceArray = price.ToString().ToCharArray();
            string toman = string.Empty;
            for (int i = 0; i < priceArray.Length; i++)
            {
                toman += priceArray[i];
                if (i == priceArray.Length - 4 || i == priceArray.Length - 7 || i == priceArray.Length - 10 || i == priceArray.Length - 13 || i == priceArray.Length - 16)
                {
                    toman += ",";
                }
            }
            return $"{toman} تومان";
        }

        public static string ToToman(this int? price)
        {
            char[] priceArray = price.ToString().ToCharArray();
            string toman = string.Empty;
            for (int i = 0; i < priceArray.Length; i++)
            {
                toman += priceArray[i];
                if (i == priceArray.Length - 4 || i == priceArray.Length - 7 || i == priceArray.Length - 10 || i == priceArray.Length - 13 || i == priceArray.Length - 16)
                {
                    toman += ",";
                }
            }
            return $"{toman} تومان";
        }



        public static PersianDateTime ToPersianDate(this DateTime dateTime)
        {
            return new PersianDateTime(dateTime);
        }



    }
}
