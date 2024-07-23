using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCodeFirst.Entity
{
    public  class Customer 
    {
        [Key]
        public int Id { get; set; }

        [StringLength(10)]
        public string FirstName { get; set; }

        [StringLength(10)]
        public string LastName { get; set; }

        [StringLength(10)]
        public string  PhoneNumber { get; set; }

        [StringLength(30)]
        public string  Password { get; set; }

        [StringLength(30)]
        public string Email { get; set; }
        public DateTime Created { get; set; }

        public ICollection<Reservation> Reservations { get; set; }

            


    }
}
