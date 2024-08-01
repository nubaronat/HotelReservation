using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs.Hotel
{
    public class GetHotelRequestDto
    {
        public int? hotelId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public float? Rating { get; set; }




    }
}
