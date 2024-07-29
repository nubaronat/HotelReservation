using Business.Abstract;
using DataAccess.Abstract;
using EfCodeFirst.Entity;
using Entity.DTOs.Customer;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;

        }
        [HttpPost]
        public IActionResult Create([FromBody] CustomerCreateRequestDto customerCreateRequestDto)
        {
            _customerService.Insert(customerCreateRequestDto);
            return Ok();
        }
        [HttpPut]
        public IActionResult Update([FromBody] CustomerUpdateRequestDto customerUpdateRequestDto)
        {
            _customerService.Update(customerUpdateRequestDto);
            return Ok();

        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _customerService.Delete(id);
            return Ok();
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var customer = _customerService.GetAll();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var customer = _customerService.GetCustomer(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
        [HttpPost("filter")]
        public IActionResult Filter([FromBody] GetCustomerRequestDto filterDto)
        {
            var customer = _customerService.Filter(filterDto);
            return Ok();
        }


    }
}