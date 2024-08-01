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
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id 0'dan büyük olmalıdır.");

            RuleFor(x => x.Type)
                .GreaterThan(0).WithMessage("Oda tipi 0'dan büyük olmalıdır.");

            RuleFor(x => x.HotelId)
                .GreaterThan(0).WithMessage("OtelId 0'dan büyük olmalıdır.");

            RuleFor(x => x.Price)
                .GreaterThanOrEqualTo(0).WithMessage("Fiyat 0'dan büyük veya eşit olmalıdır.");

            RuleFor(x => x.IsAvailable)
                .NotNull().WithMessage("Müsaitlik durumu gerekli.");

        }
    }
}
