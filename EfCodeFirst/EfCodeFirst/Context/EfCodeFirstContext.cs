using EfCodeFirst.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCodeFirst.Context
{
    public class EfCodeFirstContext:DbContext
    {
        public EfCodeFirstContext() : base("Server=localhost;Database=EfCodeFirst;User Id=sa;Password=Paycoop123!")
        {

        }
        public DbSet<Room>Romms { get; set; }
        public DbSet<Customer>Customers { get; set; }
        public DbSet<Hotel>Hotels { get; set; }
        public DbSet<Reservation>Reservations { get; set; }

        //public DbSet<Category>Categories { get; set; }

    }
}
