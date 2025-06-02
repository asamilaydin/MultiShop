using Microsoft.EntityFrameworkCore;
using MultiShop.Order.Domain.Entities;
using System.Reflection;

namespace MultiShop.Order.Infrastructure.Persistence.Context
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
        {
        }

        public DbSet<Domain.Entities.Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Domain.Entities.Order>()
                .HasMany(o => o.OrderDetails)
                .WithOne()
                .HasForeignKey(od => od.OrderId);

            modelBuilder.Entity<Domain.Entities.Order>()
                .HasOne(o => o.ShippingAddress)
                .WithMany()
                .HasForeignKey("ShippingAddressId")
                .IsRequired(false);
            
            modelBuilder.Entity<Address>()
                .HasIndex(a => a.UserId);
        }
    }
} 