using OrganicShop.Domain.Entities;

namespace OrganicShop.Domain.Entities.SeedDatas
{
    public class PermissionsSeed
    {
        public readonly byte Main_Admin = 1;

        public readonly byte Users_Admin = 2;

        public readonly byte Products_Admin = 3;

        public readonly byte Permissions_Admin = 4;

        public readonly byte Comments_Admin = 5;

        public readonly byte Discounts_Admin = 6;

        public readonly byte Giving_Permission = 7;

        //public static readonly string  = "";

        //public static readonly string  = "";

        //public static readonly string  = "";

        //public static readonly string  = "";

        //public static readonly string  = "";

        //public static readonly string  = "";

        //public static readonly string  = "";

        //public static readonly string  = "";

        //public static readonly string  = "";

        //public static readonly string  = "";


        public static readonly List<Permission> Permissions = new List<Permission>()
        {
            new Permission(){ Id = 1, Title = "مدیر سایت", EnTitle = "Main Admin",},

            new Permission(){ Id = 2, Title = "مدیریت کاربران", EnTitle = "Users Admin",ParentId = 1, },

            new Permission(){ Id = 3, Title = "مدیریت محصولات", EnTitle = "Products Admin",ParentId = 1, },

            new Permission(){ Id = 4, Title = "مدیریت مجوز ها", EnTitle = "Permissions Admin",ParentId = 1,},

            new Permission(){ Id = 5, Title = "مدیریت نظرات", EnTitle = "Comments Admin", ParentId = 1,},

            new Permission(){ Id = 6, Title = "مدیریت تخفیف ها", EnTitle = "Discounts Admin", ParentId = 1,},

            new Permission(){ Id = 7, Title = "صدور مجوز", EnTitle = "Giving Permission", ParentId = 4,},

            //new Permission(){ },
        };

    }



}
