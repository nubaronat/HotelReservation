using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs.Hotel
{
    public class HotelUpdateRequestDto
    {
        public int hotelId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Phone {  get; set; }
        public string Email { get; set; }
        public float Rating { get; set; }

    }

}
