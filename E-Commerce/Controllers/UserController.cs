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
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserRepository _userRepository;
        public UserController(UserManager<ApplicationUser> userManager,IUserRepository userRepository)
        {
            _userManager = userManager;
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterCustomerDto registerDto)
        {
            var response = _userRepository.Register(registerDto);

            if (response != null)
            {
                return Ok("User registered successfully!");
            }
            else
            {
                return BadRequest("There was something wrong during the registration process.");
            }
        }

    }
}
