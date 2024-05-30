using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DAL.Repository.IRepository
{
    public interface IUnitOfWorkRepository
    {
        IOrderRepository orderRepository { get; }
        IProductRepository productRepository { get; }
        //IUserRepository userRepository { get; }
        void save();
        
    }
}
