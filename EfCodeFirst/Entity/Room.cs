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
        public int Id { get; set; }
       
        public int Type { get; set; }
        
        [Column(TypeName ="money")]
        public decimal Price { get; set; }

        public bool IsAvailable { get; set; }
        
    
    
    
    
    }
}
