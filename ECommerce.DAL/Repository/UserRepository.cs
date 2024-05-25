using ECommerce.DAL.Repository.IRepository;
using ECommerce.Models.DtoModels;
using ECommerce.Models.EntityModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DAL.Repository
{
    public class UserRepository : Repository<ApplicationUser>, IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserRepository(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager) : base(dbContext)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }
        public async Task<RegisterCustomerDto> Register(RegisterCustomerDto registerDto)
        {
            var applicationUser = new ApplicationUser
            {
                UserName = registerDto.FirstName,
                Email = registerDto.Email,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Address = registerDto.Address,
                PurchaseHistory = registerDto.PurchaseHistory,
                Preferences = registerDto.Preferences
            };

            var identityResult = await _userManager.CreateAsync(applicationUser, registerDto.Password);

            if (identityResult.Succeeded)
            {
                if (registerDto.Roles != null && registerDto.Roles.Any())
                {
                    identityResult = await _userManager.AddToRolesAsync(applicationUser, registerDto.Roles);

                    if (identityResult.Succeeded)
                    {
                        return registerDto;
                        //return Ok("User registered successfully!");
                    }
                }
                return registerDto;
                //return Ok("User registered successfully!");
            }
            else
            {
                return null;
            }

             
            //return BadRequest("There was something wrong during the registration process.");
        }
    }
}
