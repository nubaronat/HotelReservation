using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.DTOs.Reservation;
using EfCodeFirst.Entity;
using DataAccess.Abstract;
using Business.Abstract;

namespace Business.Concrete
{
    public class ReservationManager : IReservationService
    {
        private readonly IReservationDa _reservationDal;

        public ReservationManager(IReservationDa reservationDal)
        {
            _reservationDal = reservationDal;
        }

        public void Delete(int id)
        {
            _reservationDal.Delete(id);
        }

        public IQueryable<ReservationResponseDto> Filter(GetReservationRequestDto filterDto)
        {
            var query = _reservationDal.GetAll();

            if (filterDto.Id.HasValue)
            {
                query = query.Where(reservation => reservation.Id == filterDto.Id.Value);
            }
            if (filterDto.CustomerId.HasValue)
            {
                query = query.Where(reservation => reservation.CustomerId == filterDto.CustomerId.Value);
            }
            if (filterDto.RoomId.HasValue)
            {
                query = query.Where(reservation => reservation.RoomId == filterDto.RoomId.Value);
            }
            if (filterDto.CheckInDate.HasValue)
            {
                query = query.Where(reservation => reservation.CheckInDate >= filterDto.CheckInDate.Value);
            }
            if (filterDto.CheckOutDate.HasValue)
            {
                query = query.Where(reservation => reservation.CheckOutDate <= filterDto.CheckOutDate.Value);
            }
            if (!string.IsNullOrEmpty(filterDto.ReservationStatus))
            {
                query = query.Where(reservation => reservation.ReservationStatus.Contains(filterDto.ReservationStatus));
            }

            return query.Select(reservation => new ReservationResponseDto
            {
                Id = reservation.Id,
                CustomerId = reservation.CustomerId,
                RoomId = reservation.RoomId,
                CheckInDate = reservation.CheckInDate,
                CheckOutDate = reservation.CheckOutDate,
                TotalPrice = reservation.TotalPrice,
                ReservationStatus = reservation.ReservationStatus
            });

        }




        public IQueryable<GetReservationRequestDto> GetAll()
        {
            return _reservationDal.GetAll().Select(reservation => new GetReservationRequestDto

            {

                Id = reservation.Id,
                CustomerId = reservation.CustomerId,
                RoomId = reservation.RoomId,
                CheckInDate = reservation.CheckInDate,
                CheckOutDate = reservation.CheckOutDate,
                TotalPrice = reservation.TotalPrice,
                ReservationStatus = reservation.ReservationStatus


            });
        
         }

        public ReservationResponseDto GetReservation(int id)
        {
            var reservation = _reservationDal.GetById(id);
            if (reservation == null)
            {
                return null;
            }

            return new ReservationResponseDto
            {
                Id = reservation.Id,
                CustomerId = reservation.CustomerId,
                RoomId = reservation.RoomId,
                CheckInDate = reservation.CheckInDate,
                CheckOutDate = reservation.CheckOutDate,
                TotalPrice = reservation.TotalPrice,
                ReservationStatus = reservation.ReservationStatus
            };

            
        }

        public void Insert(ReservationCreateRequestDto reservationCreateRequestDto)
        {
            var reservation = new Reservation
            {
                CustomerId = reservationCreateRequestDto.CustomerId,
                RoomId= reservationCreateRequestDto.RoomId,
                CheckInDate = reservationCreateRequestDto.CheckInDate,
                CheckOutDate = reservationCreateRequestDto.CheckOutDate,
                TotalPrice= reservationCreateRequestDto.TotalPrice,
                ReservationStatus= reservationCreateRequestDto.ReservationStatus
            };
            _reservationDal.Insert(reservation);
        }

        public void Update(ReservationUpdateRequestDto reservationUpdateRequestDto)
        {
            var reservation = _reservationDal.GetById(reservationUpdateRequestDto.Id);
            if (reservation != null)
            {
                reservation.CustomerId = reservationUpdateRequestDto.CustomerId;
                reservation.RoomId = reservationUpdateRequestDto.RoomId;
                reservation.CheckInDate = reservationUpdateRequestDto.CheckInDate;
                reservation.CheckOutDate = reservationUpdateRequestDto.CheckOutDate;
                reservation.TotalPrice = reservationUpdateRequestDto.TotalPrice;
                reservation.ReservationStatus = reservationUpdateRequestDto.ReservationStatus;
                _reservationDal.Update(reservation);
            }

        }
    }
}
