using ECommerce.Models.DtoModels;
using ECommerce.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DAL.Repository.IRepository
{
    public interface IUserRepository:IRepository<ApplicationUser>
    {
        Task<RegisterCustomerDto> Register(RegisterCustomerDto registerDto);
        Task<string> Login(UserLoginDto registerDto);
        Task<ApplicationUser> ChangePassword(ChangePasswordDto changePasswordDto);
        Task<ApplicationUser> GetAOrder(string Id);
        Task<IEnumerable<ApplicationUser>> GetAllOrder();

    }
}
