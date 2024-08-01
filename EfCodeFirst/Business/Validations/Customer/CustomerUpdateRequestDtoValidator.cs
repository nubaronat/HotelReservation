using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.DTOs.Customer;
using FluentValidation;

namespace Business.Validations.Customer
{
    public class CustomerUpdateRequestDtoValidator : AbstractValidator<CustomerUpdateRequestDto>
    {
        public CustomerUpdateRequestDtoValidator() 
        {
            RuleFor(c => c.Id)
               .GreaterThan(0).WithMessage("Id 0'dan büyük olmalıdır.");

            RuleFor(c => c.FirstName)
                .NotEmpty().WithMessage("Ad gerekli.")
                .MaximumLength(50).WithMessage("Ad en fazla 50 karakter olmalıdır.");

            RuleFor(c => c.LastName)
                .NotEmpty().WithMessage("Soyad gerekl.")
                .MaximumLength(50).WithMessage("Soyad en fazla 50 karakter olmalıdır.");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("E-posta gerekli.")
                .EmailAddress().WithMessage("Geçersiz e-posta formatı.");

            RuleFor(c => c.Password)
                .NotEmpty().WithMessage("Şifre gerekli.")
                .MaximumLength(30).WithMessage("Şifre en fazla 30 karakter olmalıdır.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
                .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
                .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
                .Matches("[0-9]").WithMessage("Password must contain at least one number.")
                .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character.");

            RuleFor(c => c.PhoneNumber)
                .NotEmpty().WithMessage("Telefon numarası gerekli.")
                .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("Geçersiz telefon numarası formatı.");
        }
    }
}
