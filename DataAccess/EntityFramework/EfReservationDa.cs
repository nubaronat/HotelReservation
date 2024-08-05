using DataAccess.Abstract;
using DataAccess.Repository;
using DataAccessLayer.Concrete;
using EfCodeFirst.Entity;
using Entity.DTOs.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess.EntityFramework
{
    public class EfReservationDa : GenericRepository<Reservation>, IReservationDa
    {
        public EfReservationDa(Context context) : base(context)
        { }
            public IQueryable<Reservation> Filter(FilterDto filterDto)
            {
                var query = _context.Reservations.AsQueryable();
                if (filterDto.Id != 0)
                    query = query.Where(R => R.Id == filterDto.Id);
                if (filterDto.RoomId != 0)
                    query = query.Where(R => R.RoomId == filterDto.RoomId);
                if (filterDto.hotelId != 0)
                    query = query.Where(R => R.hotelId == filterDto.hotelId);
                if (filterDto.CustomerId!=0 )
                    query = query.Where(R => R.CustomerId == filterDto.CustomerId);
                if (filterDto.CheckInDate.HasValue)
                    query=query.Where(R=>R.CheckInDate == filterDto.CheckInDate);
                if (filterDto.CheckOutDate.HasValue)
                    query=query.Where(R=>R.CheckOutDate == filterDto.CheckOutDate);
                if (filterDto.TotalPrice.HasValue)
                    query=query.Where(R=>R.TotalPrice == filterDto.TotalPrice);

                return query;
            }      
    }
}
