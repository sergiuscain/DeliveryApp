using Microsoft.EntityFrameworkCore;
using DeliveryApp.DB.Models;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DeliveryApp.DB
{
    public class DeliveryAppDBContext  : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<DeliveringOrder> InDelivery { get; set; }
        public DeliveryAppDBContext(DbContextOptions<DeliveryAppDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
