using DataAccess.Abstract;
using DataAccess.Repository;
using DataAccessLayer.Concrete;
using EfCodeFirst.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.DTOs.Customer;

namespace DataAccess.EntityFramework
{
    public class EfCustomerDa : GenericRepository<Customer>, ICustomerDa
    {
        public EfCustomerDa(Context context) : base(context)
        {
        }

        public IQueryable<Customer> GetCustomers(GetCustomerRequestDto filter)
        {
            var query = _context.Customers.AsQueryable();
            if (filter.Id.HasValue)
                query = query.Where(c => c.Id == filter.Id.Value);
            if (!string.IsNullOrEmpty(filter.FirstName))
                query = query.Where(c => c.FirstName == filter.FirstName);
            if (!string.IsNullOrEmpty(filter.LastName))
                query = query.Where(c => c.LastName == filter.LastName);
            if (!string.IsNullOrEmpty(filter.Email))
                query = query.Where(c => c.Email == filter.Email);
            if (!string.IsNullOrEmpty(filter.Password))
                query = query.Where(c => c.Password == filter.Password);
            if (!string.IsNullOrEmpty(filter.PhoneNumber))
                query = query.Where(c => c.PhoneNumber == filter.PhoneNumber);
            if (filter.Created.HasValue)
                query = query.Where(c => c.Created == filter.Created.Value); 
            
            return query;

        }
    }
}
