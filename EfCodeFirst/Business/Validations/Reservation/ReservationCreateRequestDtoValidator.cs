using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.DTOs.Reservation;
using FluentValidation;

namespace Business.Validations.Reservation
{
    public class ReservationCreateRequestDtoValidator : AbstractValidator<ReservationCreateRequestDto>
    {
        public ReservationCreateRequestDtoValidator() 
        {
            RuleFor(x => x.CustomerId)
                .GreaterThan(0).WithMessage("MüşteriId 0'dan büyük olmalıdır.");

            RuleFor(x => x.RoomId)
                .GreaterThan(0).WithMessage("OdaId 0'dan büyük olmalıdır.");

            RuleFor(x => x.CheckInDate)
                .NotEmpty().WithMessage("Giriş Tarihi gerekli.")
                .LessThan(x => x.CheckOutDate).WithMessage("Giriş tarihi çıkış tarihinden önce olmalıdır.");

            RuleFor(x => x.CheckOutDate)
                .NotEmpty().WithMessage("Çıkış Tarihi gerekli.");

            RuleFor(x => x.TotalPrice)
                .GreaterThanOrEqualTo(0).WithMessage("Toplam fiyat 0'dan büyük veya eşit olmalıdır.");

            RuleFor(x => x.ReservationStatus)
                .NotEmpty().WithMessage("Rezervasyon Durumu gerekli.")
                .MaximumLength(50).WithMessage("Rezervasyon Durumu en fazla 50 karakter olmalıdır.");
        }
    }
}
