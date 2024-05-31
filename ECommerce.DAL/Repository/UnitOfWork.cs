using ECommerce.DAL.Repository.IRepository;
using ECommerce.Models.EntityModels;
using Microsoft.AspNetCore.Identity;
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
        public IUserRepository userRepository {  get; private set; }
        ApplicationDbContext context;
        UserManager<ApplicationUser> _usermanager;//for user
        ITokenRepository _tokenRepository;//for user

        public UnitOfWork(ApplicationDbContext dbContext,UserManager<ApplicationUser> userManager,ITokenRepository tokenRepository)
        {
            context = dbContext;
            _usermanager = userManager;
            _tokenRepository = tokenRepository;
            this.orderRepository = new OrderRepository(context);
            this.productRepository = new ProductRepository(context);
            this.userRepository = new UserRepository(context,_usermanager, _tokenRepository);
        }

        public void save()
        {
            context.SaveChanges();
        }
    }
}
