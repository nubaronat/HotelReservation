using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCodeFirst.Entity;


public class Reservation
{
    [Key]
    public int Id { get; set; }
    
    [ForeignKey("Customer")]
    public int CustomerId { get; set; }
    public virtual Customer Customer { get; set; }

    [ForeignKey("Room")]
    public int RoomId { get; set; }
    
    [ForeignKey("Hotel")]
    public int hotelId { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public Decimal TotalPrice { get; set; }
    public string ReservationStatus { get; set; }

    

}
