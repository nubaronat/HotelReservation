using DataAccess.Abstract;
using DataAccess.Repository;
using DataAccessLayer.Concrete;
using EfCodeFirst.Entity;
using Entity.DTOs.Room;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
    public class EfRoomDa : GenericRepository<Room>, IRoomDa
    {
        public EfRoomDa(Context context) : base(context) { }

        public IQueryable<Room> GetRooms(GetRoomRequestDto filter)
        {
            var query = _context.Rooms.AsQueryable();

            if (filter.Id.HasValue)
                query = query.Where(r => r.RoomId == filter.Id.Value);
            if (filter.Type.HasValue)
                query = query.Where(r => r.Type == filter.Type.Value);
            if (filter.Price.HasValue)
                query = query.Where(r => r.Price == filter.Price.Value);
            if (filter.IsAvailable.HasValue)
                query = query.Where(r => r.IsAvailable == filter.IsAvailable.Value);

            return query;
        }
    }
}
