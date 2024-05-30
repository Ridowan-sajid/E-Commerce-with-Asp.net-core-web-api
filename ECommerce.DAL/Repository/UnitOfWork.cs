using ECommerce.DAL.Repository.IRepository;
using ECommerce.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DAL.Repository
{
    public class UnitOfWork : IUnitOfWorkRepository
    {
        public IOrderRepository orderRepository {  get; private set; }
        public IProductRepository productRepository {  get; private set; }
        //public IUserRepository userRepository {  get; private set; }
        ApplicationDbContext context;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            context = dbContext;
            this.orderRepository = new OrderRepository(context);
            this.productRepository = new ProductRepository(context);
            //this.userRepository = new UserRepository(context);
        }

        public void save()
        {
            context.SaveChanges();
        }
    }
}
