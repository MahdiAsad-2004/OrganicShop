using Microsoft.AspNetCore.Http;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.BLL.Extensions
{
    public static class FileExtensions
    {
        public static async Task<string> SaveFile(this IFormFile file, string path)
        {
            
            var fileName = $"{Guid.NewGuid().ToString().Replace("-", "").Substring(1,16)}{Path.GetExtension(file.FileName)}";

            string filePath = Path.Combine(path, fileName);

            using (var stream = new FileStream(filePath, FileMode.CreateNew))
            {
                await file.CopyToAsync(stream);
            }

            //try
            //{
            //    using (var stream = new FileStream(filePath, FileMode.Create))
            //    {
            //        await file.CopyToAsync(stream);
            //    }
            //    return true;
            //}
            //catch (Exception ex)
            //{
            //    await Console.Out.WriteLineAsync(ex.Message);
            //}
            return fileName;
        }



        public static async Task<Picture> SaveFileAsync(this IFormFile file, string path)
        {

            var fileName = $"{Guid.NewGuid().ToString().Replace("-", "").Substring(1, 16)}{Path.GetExtension(file.FileName)}";

            string filePath = Path.Combine(path, fileName);

            using (var stream = new FileStream(filePath, FileMode.CreateNew))
            {
                await file.CopyToAsync(stream);
            }

            return new Picture
            {
                Name = fileName,
                SizeMB = file.Length / 1024 / 1000,
                BaseEntity = new BaseEntity(true),
            };
        }

    }
}
