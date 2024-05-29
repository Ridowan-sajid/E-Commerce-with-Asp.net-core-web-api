using ECommerce.Models.DtoModels;
using ECommerce.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DAL.Repository.IRepository
{
    public interface IOrderRepository:IRepository<Order>
    {
        Task<Order> Update(Order product);
        Task<IEnumerable<Order>> GetAllWithUserAndProduct();
        Task<Order> GetAOrderWithUserAndProduct(Guid Id);
    }
}
