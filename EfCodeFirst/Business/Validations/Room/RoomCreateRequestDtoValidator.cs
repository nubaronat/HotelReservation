using Entity.DTOs.Room;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations.Room
{
    public class RoomCreateRequestDtoValidator : AbstractValidator<RoomCreateRequestDto>
    {

        public RoomCreateRequestDtoValidator()
        {
            RuleFor(r => r.Type)
                .NotEmpty()
                .NotNull()
                .WithMessage("Please choose type of room")
                .GreaterThanOrEqualTo(1)
                .WithMessage("Type must be an larger than 0 and positive.");

            RuleFor(r => r.HotelId)
                .NotEmpty()
                .NotNull()
                .WithMessage("Please choose a Hotel")
                .GreaterThanOrEqualTo(1)
                .WithMessage("Hotel Id must be larger than 0 and an positive.");

            RuleFor(r => r.Price)
                .NotNull()
                .NotEmpty()
                .WithMessage("Please choose price of room ")
                .GreaterThanOrEqualTo(1)
                .WithMessage("Price must be larger than 0 and positive.");

            RuleFor(r => r.IsAvailable)
                .NotEmpty()
                .NotNull()
                .WithMessage("Please choose availability of room");
                
        }
    }

}
