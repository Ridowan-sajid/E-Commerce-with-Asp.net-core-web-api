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
    public class ProductController : ControllerBase
    {
        //private readonly IProductRepository productRepository;
        private readonly IUnitOfWorkRepository unitOfWorkRepository;
        private readonly IRedisCacheRepository redisCacheRepository;
        public ProductController(IUnitOfWorkRepository unitOfWorkRepository,IRedisCacheRepository cacheRepository)
        {
            this.unitOfWorkRepository = unitOfWorkRepository;
            this.redisCacheRepository = cacheRepository;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            var res = await unitOfWorkRepository.productRepository.CreateAsync(product);

            return Ok(res);
        }
        [HttpGet]
        //[Authorize(Roles = "Admin,User")]
        //[Authorize]

        public async Task<IActionResult> GetAllProduct()
        {
            var cache = redisCacheRepository.GetData<IEnumerable<Product>>("product");
            if(cache != null)
            {
                return Ok(cache);
            }
            var res = await unitOfWorkRepository.productRepository.GetAll();
            if (res == null)
            {
                return NotFound();
            }
            redisCacheRepository.SetData("product",res);
            return Ok(res);

        }
        [HttpGet]
        [Route("{id:Guid}")]
        //[Authorize(Roles = "User")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            var res = await unitOfWorkRepository.productRepository.GetByCondition(element=>element.Id==id);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);

        }
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            var res = await unitOfWorkRepository.productRepository.Update(product);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);

        }
        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var res = await unitOfWorkRepository.productRepository.GetByCondition(element=>element.Id==id);
            if (res == null)
            {
                return NotFound();
            }
            await unitOfWorkRepository.productRepository.DeleteAsync(res);
            return Ok(res);

        }

    }
}
