using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using EfCodeFirst.Entity;
using DataAccess.Abstract;
using Business.Abstract;
using Entity.DTOs.Room;

namespace Business.Concrete
{
    public class RoomManager : IRoomService
    {
        private readonly IRoomDa _roomDal;

        public RoomManager(IRoomDa roomDal)
        {
            _roomDal = roomDal;
        }

        public void Insert(RoomCreateRequestDto roomCreateRequestDto)
        {
            var room = new Room
            {
                Type = roomCreateRequestDto.Type,
                HotelId = roomCreateRequestDto.HotelId,
                Price = roomCreateRequestDto.Price,
                IsAvailable = roomCreateRequestDto.IsAvailable
            };
            _roomDal.Insert(room);
        }

        public void Update(RoomUpdateRequestDto roomUpdateRequestDto)
        {
            var room = _roomDal.GetById(roomUpdateRequestDto.Id);
            if (room != null)
            {
                room.Type = roomUpdateRequestDto.Type;
                room.HotelId = roomUpdateRequestDto.HotelId;
                room.Price = roomUpdateRequestDto.Price;
                room.IsAvailable = roomUpdateRequestDto.IsAvailable;
                _roomDal.Update(room);
            }
        }

        public void Delete(int id)
        {
            _roomDal.Delete(id);
        }

        public IQueryable<GetRoomRequestDto> GetAll()
        {
            return _roomDal.GetAll().Select(room => new GetRoomRequestDto
            {
                Id = room.RoomId,
                Type = room.Type,
                HotelId = room.HotelId,
                Price = room.Price,
                IsAvailable = room.IsAvailable
            });
        }

        public RoomResponseDto GetById(int id)
        {
            var room = _roomDal.GetById(id);
            if (room == null)
            {
                return null;
            }
            return new RoomResponseDto
            {
                Id = room.RoomId,
                Type = room.Type,
                HotelId = room.HotelId,
                Price = room.Price,
                IsAvailable = room.IsAvailable
            };
        }

        public IQueryable<RoomResponseDto> Filter(GetRoomRequestDto filterDto)
        {
            var query = _roomDal.GetAll();

            if (filterDto.Id.HasValue)
            {
                query = query.Where(room => room.RoomId == filterDto.Id.Value);
            }
            if (filterDto.Type.HasValue)
            {
                query = query.Where(room => room.Type == filterDto.Type.Value);
            }
            if (filterDto.HotelId.HasValue)
            {
                query = query.Where(room => room.HotelId == filterDto.HotelId.Value);
            }
            if (filterDto.Price.HasValue)
            {
                query = query.Where(room => room.Price == filterDto.Price.Value);
            }
            if (filterDto.IsAvailable.HasValue)
            {
                query = query.Where(room => room.IsAvailable == filterDto.IsAvailable.Value);
            }

            
            
            return query.Select(room => new RoomResponseDto
            {
                Id = room.RoomId,
                Type = room.Type,
                HotelId = room.HotelId,
                Price = room.Price,
                IsAvailable = room.IsAvailable
            });
        }

    }  

}
