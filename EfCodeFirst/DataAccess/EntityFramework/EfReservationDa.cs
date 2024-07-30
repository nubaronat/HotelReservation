using DataAccess.Abstract;
using DataAccess.Repository;
using DataAccessLayer.Concrete;
using EfCodeFirst.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.DTOs.Reservation;


namespace DataAccess.EntityFramework
{
    public class EfReservationDa : GenericRepository<Reservation>, IReservationDa
    {
        public EfReservationDa(Context context) : base(context)
        {
        }

        public IQueryable<Reservation> GetReservations(GetReservationRequestDto filter)
        {
            var query = _context.Reservations.AsQueryable();

            if (filter.Id.HasValue)
                query = query.Where(reservation => reservation.Id == filter.Id.Value);
            if (filter.CustomerId.HasValue)
                query = query.Where(reservation => reservation.CustomerId == filter.CustomerId.Value);
            if (filter.RoomId.HasValue)
                query = query.Where(reservation => reservation.RoomId == filter.RoomId.Value);
            if (filter.CheckInDate.HasValue)
               query = query.Where(reservation => reservation.CheckInDate >= filter.CheckInDate.Value);
            if (filter.CheckOutDate.HasValue)
               query = query.Where(reservation => reservation.CheckOutDate <= filter.CheckOutDate.Value);
            if (!string.IsNullOrEmpty(filter.ReservationStatus))
               query = query.Where(reservation => reservation.ReservationStatus.Contains(filter.ReservationStatus));

            return query;
        
        }    
            
    }
}
