using Business.Abstract;
using DataAccess.Abstract;
using EfCodeFirst.Entity;
using Entity.DTOs;
using Entity.DTOs.Hotel;
using Entity.DTOs.Room;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{

    public class HotelManager : IHotelService
    {
        private readonly IHotelDa _hotelda;
        public HotelManager(IHotelDa Hotelda)
        {
            _hotelda = Hotelda;
        }

        public ResponseDto Insert(HotelCreateRequestDto hotelCreateRequestDto)
        {
            var hotel = new Hotel
            {
                Name = hotelCreateRequestDto.Name,
                Description = hotelCreateRequestDto.Description,
                Address = hotelCreateRequestDto.Address,
                City = hotelCreateRequestDto.City,
                Country = hotelCreateRequestDto.Country,
                Phone = hotelCreateRequestDto.Phone,
                Email = hotelCreateRequestDto.Email,
            };
            _hotelda.Insert(hotel);
            return new() { IsSuccess = true, Message = "Hotel Has Been Created", StatusCode = 200 };

        }
        public IQueryable<HotelResponseDto> Filter(HotelResponseDto filterDto)
        {
            var query = _hotelda.GetAll();
            if (filterDto.hotelId != 0)
            {
                query = query.Where(Hotel => Hotel.hotelId == filterDto.hotelId);
            }
            if (filterDto.Name!=null)
            {
                query = query.Where(hotel => hotel.Name == filterDto.Name);
            }
            if (filterDto.Description != null)
            {
                query = query.Where(hotel => hotel.Description == filterDto.Description);
            }
            if (filterDto.Address != null)
            {
                query = query.Where(hotel => hotel.Address == filterDto.Address);
            }
            if (filterDto.City != null)
            {
                query = query.Where(hotel => hotel.City == filterDto.City);
            }
            if (filterDto.Country != null)
            {
                query = query.Where(hotel => hotel.Country == filterDto.Country);
            }
            if (filterDto.Phone != null)
            {
                query = query.Where(hotel => hotel.Phone == filterDto.Phone);
            }
            if (filterDto.Email != null)
            {
                query = query.Where(hotel => hotel.Email == filterDto.Email);
            }
            return query.Select(hotel => new HotelResponseDto
            {
                hotelId = hotel.hotelId,
                Name = hotel.Name,
                Description = hotel.Description,
                Address = hotel.Address,
                City = hotel.City,
                Country = hotel.Country,
                Phone = hotel.Phone,
                Email = hotel.Email,
            });
        }
        public HotelResponseDto GetById(int hotelId)
        {
            var hotel = _hotelda.GetById(hotelId);
            if (hotel == null)
                return null;
            
            return new HotelResponseDto
            {
                hotelId = hotel.hotelId,
                Name = hotel.Name,
                Description= hotel.Description,
                Address = hotel.Address,
                City = hotel.City,
                Country = hotel.Country,
                Phone = hotel.Phone,
                Email = hotel.Email,
            };
        }
        public ResponseDto Update(HotelResponseDto hotelupdateRequestDto)
        {
            var hotel = _hotelda.GetById(hotelupdateRequestDto.hotelId);
            if (hotel == null)
            { 
                return new() { IsSuccess = false, Message = "Hotel Not Found!", StatusCode = 404 };
             }               
            hotel.Name = hotelupdateRequestDto.Name;
            hotel.Description = hotelupdateRequestDto.Description;
            hotel.Address = hotelupdateRequestDto.Address;
            hotel.City = hotelupdateRequestDto.City;
            hotel.Country = hotelupdateRequestDto.Country;
            hotel.Phone = hotelupdateRequestDto.Phone;
            hotel.Email = hotelupdateRequestDto.Email;
            _hotelda.Update(hotel);
            return new() { IsSuccess = true, Message = "Hotel Has Been Updated", StatusCode = 200 };
            }
        public ResponseDto Delete(int hotelıd)
        {
            if (GetById(hotelıd) == null)
            {
                return new() { IsSuccess = false, Message = "Hotel Not Found!", StatusCode = 404 };
            }  
            _hotelda.Delete(hotelıd);
            return new() { IsSuccess = true, Message = "Hotel Has Been Deleted", StatusCode = 200 };
        }
    }
}