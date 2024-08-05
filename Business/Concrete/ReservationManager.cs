using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.EntityFramework;
using EfCodeFirst.Entity;
using Entity.DTOs;
using Entity.DTOs.Hotel;
using Entity.DTOs.Reservation;
using Entity.DTOs.Room;

namespace Business.Concrete
{
    public class ReservationManager: IReservationService
    { 
        private readonly IReservationDa _reservationda;
        public ReservationManager(IReservationDa ReservationDa)
        {
            _reservationda = ReservationDa;
        }
        public List<int> GetAvailableRooms(AvailabilityCheckDto availabilityCheckDto)
        {
            var list = new List<int>();
            var reservations = _reservationda.GetAll();
            foreach (var reservation in reservations)
            {
                if (!(availabilityCheckDto.CheckInDate >= reservation.CheckOutDate ||
                      availabilityCheckDto.CheckOutDate <= reservation.CheckInDate) &&
                      availabilityCheckDto.hotelId == reservation.hotelId)
                {
                    continue;
                }
                list.Add(reservation.RoomId);
            }
            return list;
        }
        public ResponseDto Insert(AllReservationDto allReservationDto)
        {   
            if (allReservationDto.CheckInDate< DateTime.Now)
                return new() { IsSuccess = false, Message = "You Can Not Make Reservation For Past Dates", StatusCode = 404 };
            if (GetAvailableRooms(allReservationDto).Count == 0)
                return new() { IsSuccess = false, Message = "No Available Rooms In Selected Time", StatusCode = 404 };
            var reservation = new Reservation
            {
                Id = allReservationDto.Id,
                CustomerId = allReservationDto.CustomerId,
                RoomId = GetAvailableRooms(allReservationDto)[0],
                hotelId = allReservationDto.hotelId,
                CheckInDate = allReservationDto.CheckInDate,
                CheckOutDate = allReservationDto.CheckOutDate, 
                TotalPrice = allReservationDto.TotalPrice,
                ReservationStatus = allReservationDto.ReservationStatus, 
            };
            _reservationda.Insert(reservation);
            return new() { IsSuccess = true, Message = "Reservation Created Succesfully", StatusCode = 200 };
        }
        public ResponseDto Update(AllReservationDto allReservationDto)
        {
            var reservation = _reservationda.GetById(allReservationDto.Id);
            if (reservation == null)
                return new() { IsSuccess = false, Message = "Reservation Not Found!", StatusCode = 404 };
            {
            reservation.CustomerId = allReservationDto.CustomerId;
            reservation.RoomId = allReservationDto.RoomId;
            reservation.hotelId = allReservationDto.hotelId;
            reservation.CheckInDate = allReservationDto.CheckInDate;
            reservation.CheckOutDate = allReservationDto.CheckOutDate;
            reservation.TotalPrice = allReservationDto.TotalPrice;
            reservation.ReservationStatus = allReservationDto.ReservationStatus;
            _reservationda.Update(reservation);
            return new() { IsSuccess = true, Message = "Reservation Has Been Updated", StatusCode = 200 };
            }
        }
        public ResponseDto Delete(int ReservationId)
        {
            if (GetById(ReservationId) == null)
            {
                return new() { IsSuccess = false, Message = "Reservation Not Found!", StatusCode = 404 };
            }
            _reservationda.Delete(ReservationId);
            return new() { IsSuccess = true, Message = "Reservation Has Been Deleted", StatusCode = 200 };
        }
        public AllReservationDto GetById(int ReservationId)
        {
            var reservation = _reservationda.GetById(ReservationId);
            if (reservation == null)
                return null;

            return new AllReservationDto
            {
                Id = reservation.Id,
                CustomerId= reservation.CustomerId,
                RoomId= reservation.RoomId,
                hotelId = reservation.hotelId,
                CheckInDate= reservation.CheckInDate,
                CheckOutDate= reservation.CheckOutDate, 
                TotalPrice= reservation.TotalPrice,
                ReservationStatus= reservation.ReservationStatus, 
            };
        }
        public IQueryable<AllReservationDto> Filter(AllReservationDto filterDto)
        {
            var query = _reservationda.GetAll();
            if (filterDto.Id != 0)
                query = query.Where(R => R.Id == filterDto.Id);
            if (filterDto.RoomId != 0)
                query = query.Where(R => R.RoomId == filterDto.RoomId);
            if (filterDto.hotelId != 0)
                query = query.Where(R => R.hotelId == filterDto.hotelId);
            if (filterDto.CustomerId != 0)
                query = query.Where(R => R.CustomerId == filterDto.CustomerId);     
            return query.Select(Reservation => new AllReservationDto
            {
                Id = Reservation.Id,
                RoomId = Reservation.RoomId,
                hotelId = Reservation.hotelId,
                CustomerId = Reservation.CustomerId,
            });
        }
        public IQueryable<Reservation> Filter(FilterDto filterDto)
        {
            var query = _reservationda.GetAll();
            if (filterDto.Id != 0)
                query = query.Where(R => R.Id == filterDto.Id);
            if (filterDto.RoomId != 0)
                query = query.Where(R => R.RoomId == filterDto.RoomId);
            if (filterDto.hotelId != 0)
                query = query.Where(R => R.hotelId == filterDto.hotelId);
            if (filterDto.CustomerId != 0)
                query = query.Where(R => R.CustomerId == filterDto.CustomerId);
            if (filterDto.CheckInDate.HasValue)
                query = query.Where(R => R.CheckInDate == filterDto.CheckInDate);
            if (filterDto.CheckOutDate.HasValue)
                query = query.Where(R => R.CheckOutDate == filterDto.CheckOutDate);
            if (filterDto.TotalPrice.HasValue)
                query = query.Where(R => R.TotalPrice == filterDto.TotalPrice);
            return query;
        }
    }
}
