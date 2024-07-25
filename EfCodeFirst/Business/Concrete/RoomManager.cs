using Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Entity.DTOs.Room;
using EfCodeFirst.Entity;
using DataAccess.Abstract;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
namespace Business.Concrete
{
    public class RoomManager : IRoomService
    {
        private readonly IRoomDa _roomDa;

        public RoomManager(IRoomDa roomDa)
        {
            _roomDa = roomDa;
        }

        public void TDelete(int id)
        {
            _roomDa.Delete(id);
        }

        public IQueryable<Room> TGetAll()
        {
            return _roomDa.GetAll();
        }

        public Room TGetById(int id)
        {
            return _roomDa.GetById(id);
        }

        public void TInsert(Room entity)
        {
            _roomDa.Insert(entity);
        }

        public void TUpdate(Room entity)
        {
            _roomDa.Update(entity);
        }
    }

}
