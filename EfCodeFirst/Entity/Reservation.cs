using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCodeFirst.Entity
{
    
    public class Reservation
    {
        [Key]
        public int Id { get; set; }
      
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        
        [Column(TypeName ="money")]
        public Decimal TotalPrice { get; set; }

        public string ReservationStatus { get; set; }

    }
}
