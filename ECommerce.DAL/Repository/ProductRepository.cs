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
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _context;
        //private readonly DbSet<Product> _dbSet;

        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
            //_dbSet = _context.Set<Product>();
        }

        public async Task<Product> Update(Product product)
        {

            var reg = await _context.Products.FirstOrDefaultAsync(e => e.Id == product.Id);

            if (reg == null)
            {
                return null;
            }

            reg.Description = product.Description;
            reg.Specificitions = product.Specificitions;
            reg.Images = product.Images;
            reg.Price = product.Price;
            reg.InventoryLevel = product.InventoryLevel;
            reg.Category = product.Category;
            reg.Color = product.Color;
            reg.Size = product.Size;

            await _context.SaveChangesAsync();
            return reg;
         
        }
    }
}
