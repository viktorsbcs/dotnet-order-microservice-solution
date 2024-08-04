using Microsoft.EntityFrameworkCore;
using Order.API.DatabaseContexts;
using Order.API.Entities;

namespace Order.API.Repositories
{
    public interface IOrderRepository
    {
        Task<UserOrder> CreateOrderAsync(Guid orderId);
    }

    public class OrderRepository : IOrderRepository
    {
        private readonly DbContext _orderContext;

        public OrderRepository(DbContext orderContext) 
        {
            _orderContext = orderContext;
        }
        public async Task<UserOrder> CreateOrderAsync(Guid orderId)
        {
            var newUserOrder = new UserOrder() { Id = orderId, OrderDate = DateTime.UtcNow };

            await _orderContext.AddAsync(newUserOrder);
            await _orderContext.SaveChangesAsync();

            return newUserOrder;
        }
    }
}
