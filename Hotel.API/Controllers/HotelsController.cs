using Business.Abstract;
using Entity.DTOs.Hotel;
using Microsoft.AspNetCore.Mvc;
using Entity.DTOs;
namespace Hotel.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HotelsController:ControllerBase
{
    private readonly IHotelService _hotelservice;

    public HotelsController(IHotelService hotelservice)
    {
        _hotelservice = hotelservice;
    }

    [HttpGet]
    public IActionResult Filter([FromQuery] HotelResponseDto filterDto)
    {
        var Hotels = _hotelservice.Filter(filterDto);
        return Ok(Hotels);
    }
    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] HotelResponseDto hotelupdateRequestDto)
    {
        var result = _hotelservice.Update(hotelupdateRequestDto);
        return StatusCode(result.StatusCode, result);
    }
    [HttpPost]
    public IActionResult Create([FromBody] HotelCreateRequestDto hotelCreateRequestDto)
    {
        var result = _hotelservice.Insert(hotelCreateRequestDto);
        return StatusCode(result.StatusCode, result);
    }
    [HttpDelete]
    public IActionResult Delete(int id)
    {
        var result =_hotelservice.Delete(id);
        return StatusCode(result.StatusCode, result);
    }
}
