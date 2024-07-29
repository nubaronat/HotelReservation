using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Entity.DTOs.Customer;
using EfCodeFirst.Entity;
using DataAccess.Abstract;
using Business.Abstract;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    { 

        private readonly ICustomerDa _customerDal;
    
        public void Delete(int id)
        {
           _customerDal.Delete(id);
        }

        public IQueryable<CustomerResponseDto> Filter(GetCustomerRequestDto filterDto)
        {
            var query = _customerDal.GetAll();

            if (filterDto.Id.HasValue)
            {
                query = query.Where(customer => customer.Id == filterDto.Id.Value);
            }
            if (!string.IsNullOrEmpty(filterDto.FirstName))
            {
                query = query.Where(customer => customer.FirstName == filterDto.FirstName);
            }
            if (!string.IsNullOrEmpty(filterDto.LastName))
            {
                query = query.Where(customer => customer.LastName == filterDto.LastName);
            }
            if (!string.IsNullOrEmpty(filterDto.Email))
            {
                query = query.Where(customer => customer.Email == filterDto.Email);
            }
            if (!string.IsNullOrEmpty(filterDto.Password))
            {
                query = query.Where(customer => customer.Password == filterDto.Password);
            }
            if (!string.IsNullOrEmpty(filterDto.PhoneNumber))
            {
                query = query.Where(customer => customer.PhoneNumber == filterDto.PhoneNumber);
            }
            if (filterDto.Created.HasValue)
            {
                query = query.Where(customer => customer.Created == filterDto.Created.Value);
            }

            return query.Select(customer => new CustomerResponseDto
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                Password = customer.Password,
                PhoneNumber = customer.PhoneNumber,
                Created = customer.Created
            });
        }

        public IQueryable<GetCustomerRequestDto> GetAll()
        {
            return _customerDal.GetAll().Select(customer => new GetCustomerRequestDto
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                Password = customer.Password,
                PhoneNumber = customer.PhoneNumber,
                Created = customer.Created
            });
        }

        public CustomerResponseDto GetCustomer(int id)
        {
            var customer = _customerDal.GetById(id);
            if (customer == null)
            {
                return null;
            }
            return new CustomerResponseDto
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                Password = customer.Password,
                PhoneNumber = customer.PhoneNumber,
                Created = customer.Created
            };
        }

        

        public void Insert(CustomerCreateRequestDto customerCreateRequestDto)
            {
            var customer = new Customer
            {
                FirstName = customerCreateRequestDto.FirstName,
                LastName = customerCreateRequestDto.LastName,
                Email = customerCreateRequestDto.Email,
                Password = customerCreateRequestDto.Password,
                PhoneNumber = customerCreateRequestDto.PhoneNumber,

            };
            }

            public void Update(CustomerUpdateRequestDto customerUpdateRequestDto)
            {
            var customer = _customerDal.GetById(customerUpdateRequestDto.Id);
            if (customer != null)
            {
                customer.FirstName = customerUpdateRequestDto.FirstName;
                customer.LastName = customerUpdateRequestDto.LastName;
                customer.Email = customerUpdateRequestDto.Email;
                customer.Password = customerUpdateRequestDto.Password;
                customer.PhoneNumber = customerUpdateRequestDto.PhoneNumber;
            }
            {

         }
      }
        
    }
}
