using Business.Abstract;
using Entity.DTOs;
using Entity.DTOs.Hotel;
using Entity.DTOs.Reservation;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Repository;
namespace Hotel.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationServices;
        public ReservationController(IReservationService reservationServices)
        {
            _reservationServices = reservationServices;
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = _reservationServices.Delete(id);
            return StatusCode(result.StatusCode, result);
        }
        [HttpPost]
        public IActionResult Create([FromBody] AllReservationDto allReservationDto)
        {
            var result = _reservationServices.Insert(allReservationDto);
            return StatusCode(result.StatusCode, result);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] AllReservationDto allReservationDto)
        {
            var result = _reservationServices.Update(allReservationDto);
            return StatusCode(result.StatusCode, result);
        }
        [HttpGet]
        public IActionResult GetAvailableRooms([FromQuery] AvailabilityCheckDto availabilityCheckDto)
        {
            var result = _reservationServices.Update((AllReservationDto)availabilityCheckDto);
            return StatusCode(result.StatusCode, result);
        }
        //[HttpGet]
        //public IQueryable<AllReservationDto> Filter(AllReservationDto filterDto)
        //{
        //    var result = _reservationServices.Filter((AllReservationDto)filterDto);
        //    return (IQueryable<AllReservationDto>)Ok();
        //}
    }
}
