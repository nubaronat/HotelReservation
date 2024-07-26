using Business.Abstract;
using DataAccess.Abstract;
using EfCodeFirst.Entity;
using Entity.DTOs.Room;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] RoomCreateRequestDto roomCreateRequestDto)
        {
            _roomService.Insert(roomCreateRequestDto);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] RoomUpdateRequestDto roomUpdateRequestDto)
        {
            _roomService.Update(roomUpdateRequestDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _roomService.Delete(id);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var rooms = _roomService.GetAll();
            return Ok(rooms);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var room = _roomService.GetById(id);
            if (room == null)
            {
                return NotFound();
            }
            return Ok(room);
        }

        [HttpPost("filter")]
        public IActionResult Filter([FromBody] GetRoomRequestDto filterDto)
        {
            var rooms = _roomService.Filter(filterDto);
            return Ok(rooms);
        }
    }
}
