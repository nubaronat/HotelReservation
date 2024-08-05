using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs.Hotel
{
    public class HotelCreateRequestDto
    {
        public string? Name { get; set; }

        [StringLength(100)]
        public string? Description { get; set; }

        [StringLength(100)]
        public string?  Address { get; set; }

        [StringLength(100)]
        public string? City { get; set; }

        [StringLength(30)]
        public string? Country { get; set; }

        [StringLength(10)]
        public string? Phone { get; set; }

        [StringLength(30)]
        public string? Email { get; set; }

    }
}
