using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfCodeFirst.Entity;
using Entity.DTOs;
using Entity.DTOs.Hotel;
using Entity.DTOs.Reservation;

namespace Business.Abstract
{
    public interface IReservationService
    {
        public ResponseDto Insert(AllReservationDto allReservationDto);
        public ResponseDto Update(AllReservationDto allReservationDto);
        public ResponseDto Delete(int ReservationId);
        public List<int> GetAvailableRooms(AvailabilityCheckDto availabilityCheckDto);
        public AllReservationDto GetById(int ReservationId);
        public IQueryable<AllReservationDto> Filter(AllReservationDto filterDto);
        public IQueryable<Reservation> Filter(FilterDto filterDto);
    }
}