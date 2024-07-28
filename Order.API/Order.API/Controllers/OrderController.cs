using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Order.API.Entities;
using Order.API.Repositories;
using System.Reflection.Metadata.Ecma335;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepo;

        public OrderController(IOrderRepository orderRepo)
        {
            this._orderRepo = orderRepo;
        }

        [HttpPost("/createOrder")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UserOrder))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateOrder()
        {
            try
            {
                var orderId = Guid.NewGuid();
                var createdOrder = await _orderRepo.CreateOrderAsync(orderId);
                
                if (createdOrder == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Failed to create new order");
                }

                return StatusCode(StatusCodes.Status201Created, createdOrder);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
