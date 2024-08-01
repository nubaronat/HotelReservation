using EfCodeFirst.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.DTOs.Room;

namespace Business.Abstract
{
    public interface IRoomService
    {
        void Insert(RoomCreateRequestDto roomCreateRequestDto);
        void Update(RoomUpdateRequestDto roomUpdateRequestDto);
        void Delete(int id);
        
        RoomResponseDto GetById(int id);
        IQueryable<RoomResponseDto> Filter(GetRoomRequestDto filterDto);
    }
}
