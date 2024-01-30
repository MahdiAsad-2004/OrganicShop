using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.DAL.Configurations
{
    public class PermissionConfig : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {


            builder.HasMany(a => a.Subs).WithOne(a => a.Parent).HasForeignKey(a => a.ParentId);
            builder.HasMany(a => a.PermissionUsers).WithOne(a => a.Permission).HasForeignKey(a => a.PermissionId);



            builder.HasQueryFilter(a => a.SoftDelete.IsDelete == false);



            //-----------------------------------------------------------------

            builder.HasData(new Permission
            {
                Id = 1,
                Title = "مدیر سایت",
                EnTitle = "Main Admin",
            });
            builder.OwnsOne(a => a.BaseEntity).HasData(new
            {
                PermissionId = (byte)1,
                CreateDate = DateTime.Now,
                LastModified = DateTime.Now,
                IsActive = true,
            });
            builder.OwnsOne(a => a.SoftDelete).HasData(new
            {
                PermissionId = (byte)1,
                IsDelete = true,
                //DeleteDate = null,
            });

            //------------------------------------------------------------------

            builder.HasData(new Permission
            {
                Id = 2,
                Title = "مدیریت کاربران",
                EnTitle = "Users Admin",
            });
            builder.OwnsOne(a => a.BaseEntity).HasData(new
            {
                PermissionId = (byte)2,
                CreateDate = DateTime.Now,
                LastModified = DateTime.Now,
                IsActive = true,
            });
            builder.OwnsOne(a => a.SoftDelete).HasData(new
            {
                PermissionId = (byte)2,
                IsDelete = true,
                //DeleteDate = null,
            });

            //-----------------------------------------------------------------

            builder.HasData(new Permission
            {
                Id = 3,
                Title = "مدیریت محصولات",
                EnTitle = "Products Admin",
                
            });
            builder.OwnsOne(a => a.BaseEntity).HasData(new
            {
                PermissionId = (byte)3,
                CreateDate = DateTime.Now,
                LastModified = DateTime.Now,
                IsActive = true,
            });
            builder.OwnsOne(a => a.SoftDelete).HasData(new
            {
                PermissionId = (byte)3,
                IsDelete = true,
                //DeleteDate = null,
            });

            //-----------------------------------------------------------------


        }
    }
}
