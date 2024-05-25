using ECommerce.DAL.Repository.IRepository;
using ECommerce.Models.DtoModels;
using ECommerce.Models.EntityModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterCustomerDto registerDto)
        {
            var response = await _userRepository.Register(registerDto);

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
            var response = await _userRepository.Login(login);

            if (response!=null)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest("There is something wrong.");
            }
        }

    }
}
