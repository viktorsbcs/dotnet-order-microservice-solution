using Microsoft.EntityFrameworkCore;
using Order.API.Entities;

namespace Order.API.DatabaseContexts
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {
            
        }

        public DbSet<UserOrder> UserOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

    }
}
