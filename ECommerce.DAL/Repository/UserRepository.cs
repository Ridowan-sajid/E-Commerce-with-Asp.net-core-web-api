using ECommerce.DAL.Repository.IRepository;
using ECommerce.Models.DtoModels;
using ECommerce.Models.EntityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
        private readonly ITokenRepository _token;


        public UserRepository(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager, ITokenRepository token) : base(dbContext)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _token = token;
        }

        public async Task<string> Login(UserLoginDto login)
        {
           
            var user = await _userManager.FindByEmailAsync(login.Email);
            if (user != null)
            {
                var checkPassword = await _userManager.CheckPasswordAsync(user, login.Password);
                if (checkPassword)
                {
                    //Get Roles of the user
                    var roles = await _userManager.GetRolesAsync(user);
                    if (roles != null)
                    {
                        var jwtToken = _token.CreateJWTToken(user, roles.ToList());
                        return jwtToken;
                    }
                }

            }
            return null;
            
            //return BadRequest("Something is wrong");
            
        }

        public async Task<RegisterCustomerDto> Register(RegisterCustomerDto registerDto)
        {
            var applicationUser = new ApplicationUser
            {
                UserName = registerDto.Email,
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
                    }
                }
                return registerDto;
            }
            else
            {
                return null;
            }

        }


        public async Task<IEnumerable<ApplicationUser>> GetAllOrder()
        {
            var orders = await _dbContext.Users.Include(o => o.Orders).ToListAsync();
            return orders;

        }

        public async Task<ApplicationUser> GetAOrder(string Id)
        {
            var order = await _dbContext.Users.Where(element => element.Id == Id).Include(o => o.Orders).FirstOrDefaultAsync();
            return order;

        }

    }
}
