using ECommerce.DAL.Repository.IRepository;
using ECommerce.Models.EntityModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DAL.Repository
{
    public class OrderRepository:Repository<Order>,IOrderRepository
    {
        private readonly ApplicationDbContext _context;
        //private readonly DbSet<Product> _dbSet;

        public OrderRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
            //_dbSet = _context.Set<Product>();
        }

        public async Task<Order> Update(Order order)
        {

            var reg = await _context.Orders.FirstOrDefaultAsync(e => e.Id == order.Id);

            if (reg == null)
            {
                return null;
            }

            reg.UserId = order.UserId;
            reg.ProductId = order.ProductId;
            reg.ShippingAddress = order.ShippingAddress;
            reg.Status = order.Status;
            reg.Quantity = order.Quantity;
            reg.Price = order.Price;


            await _context.SaveChangesAsync();
            return reg;

        }
    }
}
