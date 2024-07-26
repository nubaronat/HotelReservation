using EfCodeFirst.Entity;
using Entity.DTOs.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRoomService
    {
        void Insert(RoomCreateRequestDto roomCreateRequestDto);
        void Update(RoomUpdateRequestDto roomUpdateRequestDto);
        void Delete(int id);
        IQueryable<RoomResponseDto> GetAll();
        RoomResponseDto GetById(int id);
        IQueryable<RoomResponseDto> Filter(GetRoomRequestDto filterDto);
    }
}
