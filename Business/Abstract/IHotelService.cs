using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.DTOs;
using Entity.DTOs.Hotel;
using Entity.DTOs.Room;
namespace Business.Abstract
{
    public interface IHotelService
    {
        public ResponseDto Insert(HotelCreateRequestDto hotelCreateRequestDto);        
        public IQueryable<HotelResponseDto> Filter(HotelResponseDto filterDto);
        public ResponseDto Update(HotelResponseDto hotelupdateRequestDto);
        public ResponseDto Delete(int hotelıd);
        public HotelResponseDto GetById(int id);
    }
}