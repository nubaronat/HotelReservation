using DataAccess.Abstract;
using DataAccess.Repository;
using DataAccessLayer.Concrete;
using EfCodeFirst.Entity;
using Entity.DTOs.Hotel;
using Entity.DTOs.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
    public class EfHotelDa : GenericRepository<Hotel>, IHotelDa
    {
        public EfHotelDa(Context context) : base(context) { }
        public IQueryable<Hotel> Filter(HotelResponseDto filter)
        {
            var query = _context.Hotels.AsQueryable();

            if (filter.hotelId!= 0)
                query = query.Where(r => r.hotelId == filter.hotelId);
            if (filter.Name!=null)
                query = query.Where(r => r.Name == filter.Name);
            if (filter.Description != null)
                query = query.Where(r => r.Description == filter.Description);
            if (filter.Address != null)
                query = query.Where(r => r.Address == filter.Address);
            if (filter.City!= null)
                query = query.Where(r => r.City == filter.City);
            if (filter.Country != null)
                query = query.Where(r => r.Country == filter.Country);
            if (filter.Phone != null)
                query = query.Where(r => r.Phone == filter.Phone);
            if (filter.Email != null)
                query = query.Where(r => r.Email == filter.Email);

            return query;
        }
    }
}
