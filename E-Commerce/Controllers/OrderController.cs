using ECommerce.DAL.Repository;
using ECommerce.DAL.Repository.IRepository;
using ECommerce.Models.DtoModels;
using ECommerce.Models.EntityModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        //private readonly IOrderRepository OrderRepository;
        private readonly IUnitOfWorkRepository unitOfWorkRepository;
        private readonly ILogger<OrderController> logger;

        public OrderController(IUnitOfWorkRepository unitOfWorkRepository,ILogger<OrderController> logger)
        {
            this.unitOfWorkRepository = unitOfWorkRepository;
            this.logger = logger;
        }

        [HttpPost]
        //[Authorize(Roles = "User,Admin")]
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
            var res = await unitOfWorkRepository.orderRepository.CreateAsync(ord);

            return Ok(res);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllOrder()
        {
            var res = await unitOfWorkRepository.orderRepository.GetAll();
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);

        }

        [HttpGet]
        [Route("UserProduct")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllOrderWithUserProduct()
        {
            try
            {
                //throw new Exception("Man made Exception");
               // logger.LogWarning("Get me through first");
                var res = await unitOfWorkRepository.orderRepository.GetAllWithUserAndProduct();
                if (res == null)
                {
                    return NotFound();
                }
                return Ok(res);
            }catch (Exception ex) {
                //logger.LogError(ex,ex.Message);
                throw;
            }
  

        }
        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetOrderById(Guid id)
        {
            var res = await unitOfWorkRepository.orderRepository.GetByCondition(element => element.Id == id);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);

        }

        [HttpGet]
        [Route("UserProduct/{id:Guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetOrderWithProductUserById(Guid id)
        {
            //var res = await OrderRepository.GetAOrderWithUserAndProduct(id);
            var res = await unitOfWorkRepository.orderRepository.GetByCondition(element=>element.Id==id,"User,Product");
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);

        }
        [HttpPut]
        [Authorize(Roles = "Admin,User")]
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
            var res = await unitOfWorkRepository.orderRepository.Update(ord);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);

        }
        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            var res = await unitOfWorkRepository.orderRepository.GetByCondition(element => element.Id == id);
            if (res == null)
            {
                return NotFound();
            }
            await unitOfWorkRepository.orderRepository.DeleteAsync(res);
            return Ok(res);

        }
    }
}
