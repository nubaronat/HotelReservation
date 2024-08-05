using EfCodeFirst.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IGenericDa<T> where T : class
    {
        void Insert (T entity);
        void Update (T entity);
        void Delete (int id);
        public List<T> GetWhere(Expression<Func<T, bool>> predicate);


        //difference between List<T>
        IQueryable<T> GetAll();
        T GetById (int id );
      
        

    }
}
