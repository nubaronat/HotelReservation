/*using Entity.DTOs.Customer;
using FluentValidation;
using Framework.Core.AspNetCore.FluentValidation;

namespace Business.Validations.Customer
{
    public class CustomerUpdateRequestDtoValidator : AbstractValidator<CustomerUpdateRequestDto>
    {
        public CustomerUpdateRequestDtoValidator()
        {
            RuleFor(r => r.FirstName)
                .NotEmptyWithErrorCode()
                .Length(1, 10);

            RuleFor(r => r.LastName)
                .NotEmptyWithErrorCode()
                .Length(1, 10);

            RuleFor(r => r.PhoneNumber)
                .NotEmptyWithErrorCode()
                .Length(1, 10);

            RuleFor(r => r.Password)
                .NotEmptyWithErrorCode()
                .Length(1, 30);

            RuleFor(r => r.Email)
                .NotEmptyWithErrorCode()
                .EmailAddress()
                .Length(1, 30);
        }
    }
}*/
