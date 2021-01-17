using System;
using Microsoft.EntityFrameworkCore;
using PurchasingSystemServices.Models;

namespace PurchasingSystemServices.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<UserBalance> UserBalances { get; set; }
        public DbSet<DocumentNumber> DocumentNumbers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DocumentNumber>()
                .Property(docno => docno.Code)
                .HasColumnType("char(3)");
        }
    }
}
