using DataAccess.Abstract;
using DataAccessLayer.Concrete;
using EfCodeFirst.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Repositories
{
    public class CustomerRepository : ICustomer
    {
        Context c = new Context();
        DbSet<Customer> _object;
        public void Delete(Customer p)
        {
            _object.Remove(p);
            c.SaveChanges();
        }

        public void Insert(Customer p)
        {
            _object.Add(p);
            c.SaveChanges();
        }

        public List<Customer> List()
        {
            return _object.ToList();
        }

        public List<Customer> List(Expression<Func<Customer, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Update(Customer p)
        {
            c.SaveChanges();
        }
    }
}
