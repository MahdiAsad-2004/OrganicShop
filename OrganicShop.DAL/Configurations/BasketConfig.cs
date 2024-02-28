using Microsoft.EntityFrameworkCore;
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
    public class BasketConfig : IEntityTypeConfiguration<Basket>
    {
        public void Configure(EntityTypeBuilder<Basket> builder)
        {
           

            builder.HasMany(a => a.CoProducts).WithOne(a => a.Basket).HasForeignKey(a => a.BasketId);
            builder.HasOne(a => a.User).WithMany(a => a.Baskets).HasForeignKey(a => a.UserId);

            builder.HasQueryFilter(a => a.BaseEntity.IsDelete == false);
        }
    }
}
