using Microsoft.EntityFrameworkCore;
using Pryanik.Entities;

namespace Pryanik.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) 
            : base(opt)
        { }

        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>()
                .HasMany(p => p.Orders)
                .WithMany(i => i.Items)
                .UsingEntity("ItemOrder");

            modelBuilder.Entity<Order>()
                .HasMany(p => p.Items)
                .WithMany(i => i.Orders)
                .UsingEntity("ItemOrder");
           
            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    Id = 1,
                    Number = 123
                });


            modelBuilder.Entity<Item>().HasData(
                new Item
                {
                    Id = 1,
                    Name = "ball"
                });

            modelBuilder.Entity("ItemOrder").HasData(
                new { ItemsId = 1, OrdersId = 1 });
        }
    }
}
