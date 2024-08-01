using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.DTOs.Hotel;
using FluentValidation;


namespace Business.Validations.Hotel
{
    public class HotelUpdateRequestDtoValidator : AbstractValidator<HotelUpdateRequestDto>
    {
        public HotelUpdateRequestDtoValidator() 
        {
            RuleFor(h => h.hotelId)
                .GreaterThan(0).WithMessage("OtelId 0'dan büyük olmalıdır");

            RuleFor(h => h.Name)
                .NotEmpty().WithMessage("Ad gerekli.")
                .MaximumLength(100).WithMessage("Ad en fazla 100 karakter olmalıdır.");
            
            RuleFor(h => h.Description)
                .NotEmpty().WithMessage("Açıklama gerekli.")
                .MaximumLength(500).WithMessage("Açıklama en fazla 500 karakter olmalıdır.");
            
            RuleFor(h => h.Country)
                .NotEmpty().WithMessage("Ülke gerekli.")
                .MaximumLength(50).WithMessage("Ülke adı en fazla 50 karakter olmalıdır. ");

            RuleFor(h => h.City)
                .NotEmpty().WithMessage("Şehir gerekli")
                .MaximumLength(50).WithMessage("Şehir adı en fazla 50 karakter olmalıdır.");

            RuleFor(h => h.Phone)
                .NotEmpty().WithMessage("Telefon numarası gerekli")
                .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("Geçersiz telefon numarası formatı.");

            RuleFor(h => h.Email)
                .NotEmpty().WithMessage("E-posta gerekli")
                .EmailAddress().WithMessage("Geçersiz e-posta adresi.");

            RuleFor(h => h.Rating)
                 .InclusiveBetween(0, 5).WithMessage("Değerlendirme 0 ile 5 arasında olmalıdır.");

        }

    }
}
