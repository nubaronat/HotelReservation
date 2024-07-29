using DataAccess.Abstract;
using DataAccess.Repository;
using DataAccessLayer.Concrete;
using EfCodeFirst.Entity;
using Entity.DTOs.Hotel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
    public class EfHotelDa : GenericRepository<Hotel>, IHotelDa
    {
        public EfHotelDa(Context context) : base(context)
        {
        }

        public IQueryable<Hotel> GetHotels(GetHotelRequestDto filter)
        {
            var query = _context.Hotels.AsQueryable();
            if (filter.hotelId.HasValue)
                query = query.Where(r =>r.hotelId == filter.hotelId.Value);
            if (!string.IsNullOrEmpty(filter.Name))
                query = query.Where(c => c.Name == filter.Name);
            if (!string.IsNullOrEmpty(filter.Country))
                query = query.Where(c => c.Country == filter.Country);
            if (!string.IsNullOrEmpty(filter.City))
                query = query.Where(c => c.City == filter.City);
            if (filter.Rating.HasValue)
                query = query.Where(r => r.Rating == filter.Rating.Value);
            
            return query;

        }
    }
}
