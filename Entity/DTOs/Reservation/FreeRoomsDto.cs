using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs.Reservation
{
    public class FreeRoomsDto
    {
        [NotNull]
        public DateTime CheckInDate { get; set; }
        [NotNull]
        public DateTime CheckOutDate { get; set; }
        [NotNull]
        
        public int hotelId { get; set; }
    }
}
