using DataAccess.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : class
    {
        private readonly Context _context;

        public ReadRepository(Context context) { _context = context; }


        public DbSet<T> Table => _context.Set<T>();


        public IQueryable<T> GetAll()
            => Table;
        
        
        public async Task<T> GetByIdAsync(int id)
        => await Table.FirstOrDefaultAsync(data => data.Equals(id));
        

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> filter)
            => await Table.FirstOrDefaultAsync(filter);

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> filter)
            => Table.Where(filter);
    }
}
