using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Entity.DTOs.Hotel;
using EfCodeFirst.Entity;
using DataAccess.Abstract;
using Business.Abstract;
using Entity.DTOs.Customer;

namespace Business.Concrete
{
    public class HotelManager : IHotelService
    {
        
        private readonly IHotelDa _hotelDal;
        public void Delete(int id)
        {
            _hotelDal .Delete(id);
        }

        public IQueryable<HotelResponseDto> Filter(GetHotelRequestDto filterDto)
        {
            var query = _hotelDal.GetAll();

            if (filterDto.hotelId.HasValue)
            {
                query = query.Where(hotel => hotel.hotelId == filterDto.hotelId.Value);
            }
            if (!string.IsNullOrEmpty(filterDto.Name))
            {
                query = query.Where(hotel => hotel.Name == filterDto.Name);
            }
            if (!string.IsNullOrEmpty(filterDto.Country))
            {
                query = query.Where(hotel => hotel.Country == filterDto.Country);
            }
            if (!string.IsNullOrEmpty(filterDto.City))
            {
                query = query.Where(hotel => hotel.City == filterDto.City);
            }
            if (filterDto.Rating.HasValue)
            {
                query = query.Where(hotel => hotel.Rating == filterDto.Rating);
            }

            return query.Select(hotel => new HotelResponseDto
            {
                hotelId = hotel.hotelId,
                Name = hotel.Name,
                Country = hotel.Country,
                City = hotel.City,
                Rating = hotel.Rating
               
            });
        }

        public IQueryable<GetHotelRequestDto> GetAll()
        {
            return _hotelDal.GetAll().Select(hotel => new GetHotelRequestDto
            {
                hotelId = hotel.hotelId,
                Name = hotel.Name,
                Country = hotel.Country,
                City = hotel.City,
                Rating = hotel.Rating

            });
        }

        public HotelResponseDto GetHotel(int id)
        {
            var hotel = _hotelDal.GetById(id);
            if (hotel == null)
            {
                return null;

            }
            return new HotelResponseDto

            {
                hotelId = hotel.hotelId,
                Name = hotel.Name,
                Description = hotel.Description,
                Country = hotel.Country,
                City = hotel.City,
                Phone = hotel.Phone,
                Email = hotel.Email,
                Rating = hotel.Rating
            };


        }

        public void Insert(HotelCreateRequestDto hotelCreateRequestDto)
        {
            var hotel = new Hotel
            {
                Name = hotelCreateRequestDto.Name,
                Description = hotelCreateRequestDto.Description,
                Country = hotelCreateRequestDto.Country,
                City = hotelCreateRequestDto.City,
                Address = hotelCreateRequestDto.Address,
                Phone = hotelCreateRequestDto.Phone,
                Email = hotelCreateRequestDto.Email,
                Rating= hotelCreateRequestDto.Rating,


            };
        }

        public void Update(HotelUpdateRequestDto hotelUpdateRequestDto)
        {
            var hotel = _hotelDal.GetById(hotelUpdateRequestDto.hotelId);
            if (hotel != null) 
            {
                hotel.hotelId = hotelUpdateRequestDto.hotelId;
                hotel.Name = hotelUpdateRequestDto.Name;    
                hotel.Description = hotelUpdateRequestDto.Description;
                hotel.Country = hotelUpdateRequestDto.Country;  
                hotel.City = hotelUpdateRequestDto.City;    
                hotel.Phone = hotelUpdateRequestDto.Phone;
                hotel.Email = hotelUpdateRequestDto.Email;
                hotel.Rating = hotelUpdateRequestDto.Rating;
            }
        }
    }
}
