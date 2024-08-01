using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.DTOs.Reservation;
using FluentValidation;


namespace Business.Validations.Reservation
{
    public class GetReservationRequestDtoValidator : AbstractValidator<GetReservationRequestDto>    
    {
        public GetReservationRequestDtoValidator() 
        {
            RuleFor(r => r.Id)
                .GreaterThan(0).WithMessage("Id 0'dan büyük olmalıdır.");

            RuleFor(r => r.CustomerId)
                .GreaterThan(0).WithMessage("MüşteriId 0'dan büyük olmalıdır.");

            RuleFor(r => r.RoomId)
                .GreaterThan(0).WithMessage("OdaId 0'dan büyük olmalıdır.");

            RuleFor(r => r.CheckInDate)
                .NotEmpty().WithMessage("Giriş Tarihi gerekli.")
                .LessThan(x => x.CheckOutDate).WithMessage("Giriş tarihi çıkış tarihinden önce olmalıdır.");

            RuleFor(r => r.CheckOutDate)
                .NotEmpty().WithMessage("Çıkış Tarihi gerekli.");

            RuleFor(r => r.TotalPrice)
                .GreaterThanOrEqualTo(0).WithMessage("Toplam fiyat 0'dan büyük veya eşit olmalıdır.");

            RuleFor(r => r.ReservationStatus)
                .NotEmpty().WithMessage("Rezervasyon Durumu gerekli.")
                .MaximumLength(50).WithMessage("Rezervasyon Durumu en fazla 50 karakter olmalıdır.");
        }
    }
}
