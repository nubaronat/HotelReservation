using EfCodeFirst.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;

namespace Entity.DTOs.Reservation
{
    public class AllReservationDto : AvailabilityCheckDto
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        [ForeignKey("Room")]
        public int RoomId { get; set; }

        [ForeignKey("Hotel")]
        
        public int hotelId { get; set; }
        [NotNull]
        public DateTime CheckInDate { get; set; }
        [NotNull]
        public DateTime CheckOutDate { get; set; }

        public Decimal TotalPrice { get; set; }
        public string ReservationStatus { get; set; }

    }
}
