using Entity.DTOs.Room;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.DTOs.Room;
using FluentValidation;

namespace Business.Validations.Room
{
    public class GetRoomRequestDtoValidator : AbstractValidator<GetRoomRequestDto>
    {

        public GetRoomRequestDtoValidator() 
        {
            RuleFor(r => r.Id)
                .Must(id => !id.HasValue || id > 0)
                .WithMessage("Id must be a positive integer.");

            RuleFor(r => r.Type)
                .Must(type => !type.HasValue || type > 0)
                .WithMessage("Type must be a positive integer.");

            RuleFor(r => r.HotelId)
                .Must(hotelId => !hotelId.HasValue || hotelId > 0)
                .WithMessage("HotelId must be a positive integer.");

            RuleFor(r => r.Price)
                .Must(price => !price.HasValue || price > 0)
                .WithMessage("Price must be a positive decimal.");

            RuleFor(x => x.HotelId)
                .GreaterThan(0).WithMessage("OtelId 0'dan büyük olmalıdır.");

            RuleFor(x => x.Price)
                .GreaterThanOrEqualTo(0).WithMessage("Fiyat 0'dan büyük veya eşit olmalıdır.");

            RuleFor(x => x.IsAvailable)
                .NotNull().WithMessage("Müsaitlik durumu gerekli.");
        }



    }
}
