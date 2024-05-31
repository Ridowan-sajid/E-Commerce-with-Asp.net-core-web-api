using ECommerce.DAL.Repository;
using ECommerce.DAL.Repository.IRepository;
using ECommerce.Models.DtoModels;
using ECommerce.Models.EntityModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWorkRepository unitOfWorkRepository;
        public UserController(IUnitOfWorkRepository unitOfWorkRepository)
        {
            this.unitOfWorkRepository = unitOfWorkRepository;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterCustomerDto registerDto)
        {
            var response = await unitOfWorkRepository.userRepository.Register(registerDto);

            if (response != null)
            {
                return Ok("User registered successfully!");
            }
            else
            {
                return BadRequest("There was something wrong during the registration process.");
            }
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto login)
        {
            var response = await unitOfWorkRepository.userRepository.Login(login);

            if (response!=null)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest("There is something wrong.");
            }
        }
        [HttpPost]
        [Route("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto changePassword)
        {
            var response = await unitOfWorkRepository.userRepository.ChangePassword(changePassword);

            if (response != null)
            {
                return Ok("Successfully Changed Password");
            }
            else
            {
                return BadRequest("There is something wrong.");
            }
        }
        [HttpGet]
        [Route("AllUsers")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllUserDeails()
        {
            var res = await unitOfWorkRepository.userRepository.GetAllOrder();
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);

        }
        [HttpGet]
        [Route("order/{Id}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetAOrders(string Id)
        {
            //var res = await _userRepository.GetAOrder(Id);
            var res = await unitOfWorkRepository.userRepository.GetByCondition(element => element.Id == Id,"Orders");
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);

        }
    }
}
