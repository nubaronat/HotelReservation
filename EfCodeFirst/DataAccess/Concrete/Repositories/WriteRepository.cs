using DataAccess.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : class
    {
         private readonly Context _context;


        public WriteRepository(Context context) { _context = context; }


        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T filter)
        {
            EntityEntry<T> entityEntry = await Table.AddAsync(filter);
            
            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<T> datas)
        {
            await Table.AddRangeAsync(datas);
            return true;
        }

        public bool Remove(T filter)
        {
            EntityEntry<T> entityEntry =  Table.Remove(filter);
            return entityEntry.State == EntityState.Deleted;
        }
        public bool RemoveRange(List<T> filter)
        {
            Table.RemoveRange(filter);
            return true;
        }
         public async Task<bool> RemoveAsync(int id)
        {
            T model = await Table.FirstOrDefaultAsync(data => data.Equals(id));
            return Remove(model);
        }
        

        public async Task<int> SaveAsync()
         => await _context.SaveChangesAsync();

        public bool Update(T filter)
        {
            EntityEntry<T> entityEntry = Table.Update(filter);
            return entityEntry.State == EntityState.Modified;
        }

       

        
    }
}
