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
        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(20)]
        public string LastName { get; set; }
        [Required]
        [StringLength(10)]

        public string  PhoneNumber { get; set; }
        [Required]
        [StringLength(30)]

        public string  Password { get; set; }
        [Required]
        [StringLength(100)]

        public string Email { get; set; }
        public DateTime Created { get; set; }

            


    }
}
