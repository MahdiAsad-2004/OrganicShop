using Microsoft.EntityFrameworkCore;
using OrganicShop.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.DAL
{
    public class OrganicShopDbContext : DbContext
    {
        #region db set

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<BankCard> BankCards { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<CoProduct> CoProducts { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Faq> Faqs { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<OrderTrack> OrderTracks { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }

        #endregion




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.; Database=OrganicShopDb; Trusted_Connection=True;  TrustServerCertificate=True;");
        }
    }
}
