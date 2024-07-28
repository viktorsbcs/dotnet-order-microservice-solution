﻿using Order.API.DatabaseContexts;
using Order.API.Entities;

namespace Order.API.Repositories
{
    public interface IOrderRepository
    {
        Task<UserOrder> CreateOrderAsync(Guid orderId);
    }

    public class OrderRepository : IOrderRepository
    {
        private readonly OrderContext _orderContext;

        public OrderRepository(OrderContext orderContext) 
        {
            this._orderContext = orderContext;
        }
        public async Task<UserOrder> CreateOrderAsync(Guid orderId)
        {
            var newUserOrder = new UserOrder() { Id = orderId };
            await _orderContext.AddAsync(newUserOrder);
            await _orderContext.SaveChangesAsync();
            return newUserOrder;
        }
    }
}
