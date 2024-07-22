using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EfCodeFirst.Entity
{
    public class Hotel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        public string Description { get; set; }
        [Required]
        [StringLength(100)]
        public string Address { get; set; }
        [Required]
        [StringLength(30)]
        public string City { get; set; }
        [Required]
        [StringLength(30)]
        public string Country { get; set; }
        [Required]
        [StringLength(10)]
        public string Phone { get; set; }
        [Required]
        [StringLength(100)]
        public string Email { get; set; }
        public float Rating { get; set; }

    }
}
