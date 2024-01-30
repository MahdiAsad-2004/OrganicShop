using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Entities.Relations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.DAL.Configurations
{
    public class DiscountUsersConfig : IEntityTypeConfiguration<DiscountUsers>
    {
        public void Configure(EntityTypeBuilder<DiscountUsers> builder)
        {
           



            builder.HasOne(a => a.Discount).WithMany(a => a.DiscountUsers).HasForeignKey(a => a.DiscountId);
            builder.HasOne(a => a.User).WithMany(a => a.DiscountUsers).HasForeignKey(a => a.UserId);



            builder.HasQueryFilter(a => a.SoftDelete.IsDelete == false);
        }
    }
}
