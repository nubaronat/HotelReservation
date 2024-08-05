using EfCodeFirst.Entity;
using Entity.DTOs.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IRoomDa : IGenericDa<Room>
    {
        // Add method for filtering rooms
        IQueryable<Room> GetRooms(GetRoomRequestDto filter);
    }
}
