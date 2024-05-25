using ECommerce.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DAL.Repository.IRepository
{
    public interface IProductRepository:IRepository<Product>
    {
        Task<Product> Update(Product product);
    }
}
