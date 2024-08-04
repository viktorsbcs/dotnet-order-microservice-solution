using Microsoft.EntityFrameworkCore;
using Order.API.Entities;

namespace Order.API.DatabaseContexts
{
    public class OrderContext : DbContext
    {
        private readonly DbContextOptions<OrderContext> _options;
        private readonly ILogger<OrderContext> _logger;

        public OrderContext(DbContextOptions<OrderContext> options, ILogger<OrderContext> logger) : base(options)
        {
            _options = options;
            _logger = logger;
        }

        public DbSet<UserOrder> UserOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }

    }
}
