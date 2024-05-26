using ECommerce.DAL.Repository.IRepository;
using ECommerce.Models.DtoModels;
using ECommerce.Models.EntityModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository OrderRepository;
        public OrderController(IOrderRepository OrderRepository)
        {
            this.OrderRepository = OrderRepository;
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] OrderDto Order)
        {
            Order ord = new Order()
            {
                Id = Order.Id,
                Price = Order.Price,
                Quantity = Order.Quantity,
                Status = Order.Status,
                ShippingAddress = Order.ShippingAddress,
                ProductId = Order.ProductId,
                UserId = Order.UserId,
            };
            var res = await OrderRepository.CreateAsync(ord);

            return Ok(res);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllOrder()
        {
            var res = await OrderRepository.GetAll();
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);

        }
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetOrderById(Guid id)
        {
            var res = await OrderRepository.GetByCondition(element => element.Id == id);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);

        }
        [HttpPut]
        public async Task<IActionResult> UpdateOrder(OrderDto Order)
        {
            Order ord = new Order()
            {
                Id = Order.Id,
                Price = Order.Price,
                Quantity = Order.Quantity,
                Status = Order.Status,
                ShippingAddress = Order.ShippingAddress,
                ProductId = Order.ProductId,
                UserId = Order.UserId,
            };
            var res = await OrderRepository.Update(ord);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);

        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            var res = await OrderRepository.GetByCondition(element => element.Id == id);
            if (res == null)
            {
                return NotFound();
            }
            await OrderRepository.DeleteAsync(res);
            return Ok(res);

        }
    }
}
