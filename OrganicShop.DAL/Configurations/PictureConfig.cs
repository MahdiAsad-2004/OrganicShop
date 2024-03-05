﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.DAL.Configurations
{
    public class PictureConfig : IEntityTypeConfiguration<Picture>
    {
        public void Configure(EntityTypeBuilder<Picture> builder)
        {
          


            builder.HasOne<Product>(a => a.Product).WithMany(a => a.Pictures).HasForeignKey(a => a.ProductId);


            builder.HasQueryFilter(a => a.BaseEntity.IsDelete == false);
        }
    }
}