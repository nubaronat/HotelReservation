/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        Task<ApiResult<long>> CreateCustomerAsync(CustomerCreateRequestDto customerCreateRequestDto);
        Task<ApiResult> UpdateCustomerAsync(long id, CustomerUpdateRequestDto customerUpdateCreateDto);
        Task<ApiResult<CustomerResponseDto>> GetCustomerAsync(long id);
        Task<ApiResult<PaginatedResultDto<CustomerResponseDto>>> GetAllAsync(GetCustomerRequestDto getCsutomerRequestDto);
        Task<ApiResult> DeleteCustomerAsync(long id);
        Task<ApiResult<List<GetAllGroupCodesResponseDto>>> GetAllGroupCodes();
    }
}*/
