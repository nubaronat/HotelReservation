using Business.Abstract;
using DataAccess.Abstract;
using EfCodeFirst.Entity;
using Entity.DTOs.Reservation;
using Microsoft.AspNetCore.Mvc;



namespace Hotel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService) 
        {
            _reservationService = reservationService;
        }
        [HttpPost]
        public IActionResult Create([FromBody] ReservationCreateRequestDto reservationCreateRequestDto)
        {
            _reservationService.Insert(reservationCreateRequestDto);
            return Ok();
        }
        [HttpPut]
        public IActionResult Update([FromBody] ReservationUpdateRequestDto reservationUpdateRequestDto) 
        {
            _reservationService.Update(reservationUpdateRequestDto);
            return Ok();    
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _reservationService.Delete(id);
            return Ok();
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var reservations = _reservationService.GetAll();
            return Ok(reservations);
        }
        
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var reservation = _reservationService.GetReservation(id);
            if (reservation == null)
            {
                return NotFound();
            }
            return Ok(reservation);
        }
        
        [HttpGet("filter")]
        public IActionResult Filter([FromQuery]GetReservationRequestDto filterDto)
        {
            var reservaitons = _reservationService.Filter(filterDto);
            return Ok(reservaitons);
        }


    }
}
