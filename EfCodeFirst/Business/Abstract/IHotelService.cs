using EfCodeFirst.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.DTOs.Hotel;

namespace Business.Abstract
{
    public interface IHotelService
    {
        void Insert(HotelCreateRequestDto hotelCreateRequestDto);
        void Update(HotelUpdateRequestDto hotelUpdateRequestDto);
        void Delete(int id);
        IQueryable<GetHotelRequestDto> GetAll();
        HotelResponseDto GetHotel(int id);
        IQueryable<HotelResponseDto> Filter(GetHotelRequestDto filterDto);

    }
}
