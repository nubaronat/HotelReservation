using Azure.Core;
using DataAccess.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class GenericRepository<T> : IGenericDa<T> where T : class

    {
        protected readonly Context _context;

        public GenericRepository(Context context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            var value = _context.Set<T>().Find(id);
            if (value != null)
            {
                _context.Set<T>().Remove(value);
                _context.SaveChanges();
            }
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Insert(T entity)
        {
           _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity); 
            _context.SaveChanges();
            
        }
    }
}
