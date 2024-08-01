using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.DTOs.Room;
using FluentValidation;

namespace Business.Validations.Room
{
    public class RoomUpdateRequestDtoValidator : AbstractValidator<RoomUpdateRequestDto>
    {
        public RoomUpdateRequestDtoValidator() 
        {
            RuleFor(r => r.Id)
                .GreaterThan(0).WithMessage("Id 0'dan büyük olmalıdır.");

            RuleFor(r => r.Type)
                .GreaterThan(0).WithMessage("Oda tipi 0'dan büyük olmalıdır.");

            RuleFor(r => r.HotelId)
                .GreaterThan(0).WithMessage("OtelId 0'dan büyük olmalıdır.");

            RuleFor(r => r.Price)
                .GreaterThanOrEqualTo(0).WithMessage("Fiyat 0'dan büyük veya eşit olmalıdır.");

            RuleFor(r => r.IsAvailable)
                .NotNull().WithMessage("Müsaitlik durumu gerekli.");

        }
    }
}
