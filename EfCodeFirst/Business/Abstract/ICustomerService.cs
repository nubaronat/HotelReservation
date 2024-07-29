using EfCodeFirst.Entity;
using Entity.DTOs.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        void Insert(CustomerCreateRequestDto  customerCreateRequestDto);
        void Update(CustomerUpdateRequestDto customerUpdateRequestDto);
        void Delete(int id);
        IQueryable<GetCustomerRequestDto> GetAll();
        CustomerResponseDto GetCustomer(int id);
        IQueryable<CustomerResponseDto> Filter(GetCustomerRequestDto filterDto);

        


    }
}
