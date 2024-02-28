using Microsoft.AspNetCore.Http;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Base;


namespace OrganicShop.BLL.Mappers
{
    public static class PictureMappers
    {
        public static Picture ToPicture(this IFormFile file)
        {
            return new Picture
            {
                Name = file.Name,
                SizeMB = file.Length / 1024 / 1024,
                BaseEntity = new BaseEntity(true),
            };
        }


        public static string SavePicture(this Picture picture, string path)
        {
            return "";
        }


    }
}
