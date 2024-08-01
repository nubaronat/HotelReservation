using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.DTOs.Reservation;

namespace Business.Abstract
{
    public interface IReservationService
    {
        void Insert(ReservationCreateRequestDto reservationCreateRequestDto);
        void Update(ReservationUpdateRequestDto reservationUpdateRequestDto);
        void Delete(int id);
        IQueryable<GetReservationRequestDto> GetAll();
        ReservationResponseDto GetReservation(int id);
        IQueryable<ReservationResponseDto> Filter(GetReservationRequestDto filterDto);
    }
}
