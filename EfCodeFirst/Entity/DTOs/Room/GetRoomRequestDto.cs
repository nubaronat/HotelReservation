using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs.Room
{
    public class GetRoomRequestDto
    {
        public int? Id { get; set; }
        public int? Type { get; set; }
        public int? HotelId { get; set; }
        public decimal? Price { get; set; }
        public bool? IsAvailable { get; set; }
    }
}
