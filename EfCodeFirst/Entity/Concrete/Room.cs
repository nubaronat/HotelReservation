using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCodeFirst.Entity
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }
        public int Type { get; set; }
        public int HotelId { get; set; }


        [ForeignKey(nameof(HotelId))]
        public virtual Hotel Hotel { get; set; }

        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
