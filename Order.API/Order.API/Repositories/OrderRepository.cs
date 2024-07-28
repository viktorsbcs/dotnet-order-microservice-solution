using Order.API.Entities;

namespace Order.API.Repositories
{
    public interface IOrderRepository
    {
        Task<UserOrder> CreateOrder();
    }

    public class OrderRepository : IOrderRepository
    {
        public async Task<UserOrder> CreateOrder()
        {
            throw new NotImplementedException();
        }
    }
}
