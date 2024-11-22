using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DAL.Repository.IRepository
{
    public interface IRedisCacheRepository
    {
        T? GetData<T>(string key);
        void SetData<T>(string key, T data);
    }
}
