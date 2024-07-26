/*using Business.Abstract;
using Entity.DTOs.Customer;
using Framework.Core.AspNetCore.ResponseModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers;

namespace WebApi.Controllers
{
    public class CustomerController : MainApiController
    {
        public ICustomerService CustomerService { get; set; }

        [HttpGet]
        [ProducesResponseType(typeof(ApiResult<PaginatedResultDto<CustomerResponseDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync([FromQuery] GetCustomerRequestDto getCustomerRequestDto)
        {
            var result = await CustomerService.GetAllAsync(getCustomerRequestDto);
            return Ok(result);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateCustomer(CustomerCreateRequestDto customerCreateRequestDto)
        {
            var result = await CustomerService.CreateCustomerAsync(customerCreateRequestDto);
            return Ok(result);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateCustomer(long id, CustomerUpdateRequestDto customerUpdateRequestDto)
        {
            var result = await CustomerService.UpdateCustomerAsync(id, customerUpdateRequestDto);
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCustomer(long id)
        {
            var result = await CustomerService.GetCustomerAsync(id);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(typeof(ApiResult), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteCustomer(long id)
        {
            var result = await CustomerService.DeleteCustomerAsync(id);
            return Ok(result);
        }
    }
}*/
