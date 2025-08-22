using Microsoft.EntityFrameworkCore;
using RestauranteAPI.Domain.Entities;

namespace RestauranteAPI.Infrastructure.Context
{
    public class RestauranteContext : DbContext
    {
        public RestauranteContext(DbContextOptions<RestauranteContext> options)
            : base(options) { }

        public DbSet<Table> Tables { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure entities aqui (Table, Product, Order, OrderItem)
        }
    }
}
