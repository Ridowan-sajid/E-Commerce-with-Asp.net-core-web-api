﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DAL.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByCondition(Expression<Func<T, bool>> expression,string? includeProperties=null);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetListByCondition(Expression<Func<T, bool>> expression=null,string? includeProperties = null);
        Task<T> CreateAsync(T entity);
        Task<T> DeleteAsync(T entity);

    }
}
