using OrganicShop.Domain.Dtos.PictureDtos;
using OrganicShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.BLL.Extensions
{
    public static class PathExtensions
    {
        
        public static string CurrentDirectory = Directory.GetCurrentDirectory();

        public static string CategoryImages = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\media\\images\\category\\");

        public static string UserImages = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\media\\images\\user\\");
        
        public static string UserImageDefault = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\media\\images\\user\\user.png");

        public static string ProductImages = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\media\\images\\product\\");

        
        
        public static string GetPictureFilePath(this Picture picture)
        {
            string filePath = string.Empty;

            if (picture.ProductId != null)
                return Path.Combine(ProductImages, picture.Name);

            if (picture.CategoryPictureId != null)
                return Path.Combine(CategoryImages, picture.Name);

            if (picture.UserPictureId != null)
                return Path.Combine(UserImages, picture.Name);

            throw new Exception("Picture file path not found");
        }

        public static string GetPictureUrl(this Picture picture)
        {
            if (picture.ProductId != null)
                return $"/media/images/product/{picture.Name}";

            if (picture.CategoryPictureId != null)
                return $"/media/images/category/{picture.Name}";
            
            if (picture.UserPictureId != null)
                return $"/media/images/userr/{picture.Name}";

            throw new Exception("Picture url not found");
        }
        public static string GetPictureUrl(this PictureListDto picture)
        {
            if (picture.ProductId != null)
                return $"/media/images/product/{picture.Name}";

            if (picture.CategoryPictureId != null)
                return $"/media/images/category/{picture.Name}";

            if (picture.UserPictureId != null)
                return $"/media/images/userr/{picture.Name}";

            throw new Exception("Picture url not found");
        }
    }
}
