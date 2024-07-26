using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IWriteRepository<T> : IRepository<T> where T : class
    {
        Task<bool> AddAsync(T filter);
        Task<bool> AddRangeAsync(List<T> datas);
        bool RemoveRange(List<T> filter);
        Task<bool> RemoveAsync(int id);

        bool Update(T filter);

        Task<int> SaveAsync();



    }
}
