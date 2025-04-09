using OrderApp;
using System.Data.Entity;

namespace OrderApp
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext() : base("name=OrderDbConnection") { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
