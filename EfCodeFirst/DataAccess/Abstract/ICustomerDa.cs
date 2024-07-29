using EfCodeFirst.Entity;
using Entity.DTOs.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICustomerDa : IGenericDa<Customer>
    {
        // Add method for filtering customer
        IQueryable<Customer> GetCustomers(GetCustomerRequestDto filter);
    }
}
