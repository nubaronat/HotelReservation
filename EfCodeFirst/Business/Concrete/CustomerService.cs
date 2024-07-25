
/*using Entity.Concrete;
using Framework.Core.AspNetCore.KnownExceptions;
using Framework.Core.AspNetCore.ResponseModels;
using Framework.Core.Entity.Concrete;
using Framework.Core.Extensions;
using Framework.Core.Extensions.Paging;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Business.Concrete
{
    public class CustomerService : BaseService, ICustomerService
    {
        public async Task<ApiResult<long>> CreateCustomerAsync(CustomerCreateRequestDto customerCreateRequestDto)
        {
            var entity = Mapper.Map<Customer>(customerCreateRequestDto);
            await Db.GetDefaultRepo<Customer>().InsertAsync(entity);
            Db.Commit();
            return entity.Id;
        }

        public async Task<ApiResult> UpdateCustomerAsync(long id, CustomerUpdateRequestDto customerUpdateRequestDto)
        {
            var repo = Db.GetDefaultRepo<Customer>();
            var entity = await repo.GetAsync(s => s.Id == id);

            if (entity is null)
                return await ExceptionFactory.CreateAsync(KnownExceptionType.NotFound);

            Mapper.Map(customerUpdateRequestDto, entity);
            await repo.SaveChanges();
            Db.Commit();

            return new ApiResult();
        }

        public async Task<ApiResult<CustomerResponseDto>> GetCustomerAsync(long id)
        {
            var repo = Db.GetDefaultRepo<Customer>();
            var entity = await repo
                            .GetAsync(s => s.Id == id);

            return entity == null
                ? await ExceptionFactory.CreateAsync(KnownExceptionType.NotFound)
                : Mapper.Map<CustomerResponseDto>(entity);
        }

        public async Task<ApiResult<PaginatedResultDto<CustomerResponseDto>>> GetAllAsync(GetCustomerRequestDto getCustomerRequestDto)
        {
            var query = Db.GetDefaultRepo<Customer>().GetMany().AsNoTracking();

            if (getCustomerRequestDto.Id > 0)
                query = query.Where(d => d.Id == getCustomerRequestDto.Id);

            if (getCustomerRequestDto.FirstName.IsNotNullOrEmpty())
                query = query.Where(d => d.FirstName == getCustomerRequestDto.FirstName);

            if (getCustomerRequestDto.LastName.IsNotNullOrEmpty())
                query = query.Where(d => d.LastName == getCustomerRequestDto.LastName);

            if (getCustomerRequestDto.PhoneNumber.IsNotNullOrEmpty())
                query = query.Where(d => d.PhoneNumber == getCustomerRequestDto.PhoneNumber);

            if (getCustomerRequestDto.Email.IsNotNullOrEmpty())
                query = query.Where(d => d.Email == getCustomerRequestDto.Email);

            int totalCount = query.Count();
            int totalPageCount = (int)Math.Ceiling((double)totalCount / getCustomerRequestDto.Size);

            var customers = await query.ApplyPaging(getCustomerRequestDto.Page, getCustomerRequestDto.Size, getCustomerRequestDto.OrderBy, getCustomerRequestDto.OrderByDescending)
                                    .Select(s => new CustomerResponseDto
                                    {
                                        Id = s.Id,
                                        FirstName = s.FirstName,
                                        LastName = s.LastName,
                                        PhoneNumber = s.PhoneNumber,
                                        Email = s.Email,
                                        Created = s.Created
                                    })
                                    .ToListAsync();

            if (!customers.Any())
                return await ExceptionFactory.CreateAsync(KnownExceptionType.NotFound);

            var result = new PaginatedResultDto<CustomerResponseDto>()
            {
                Entities = customers,
                HasNextPage = totalPageCount > getCustomerRequestDto.Page,
                TotalCount = totalCount,
                TotalPageCount = totalPageCount
            };

            return result;
        }

        public async Task<ApiResult> DeleteCustomerAsync(long id)
        {
            var repo = Db.GetDefaultRepo<Customer>();
            var entity = await repo.GetAsync(s => s.Id == id);

            if (entity == null)
                return await ExceptionFactory.CreateAsync(KnownExceptionType.NotFound);

            entity.IsDeleted = true;

            await repo.SaveChanges();
            Db.Commit();
            return new ApiResult();
        }
    }
}*/
