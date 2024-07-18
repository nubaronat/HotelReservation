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
        public DbSet<Product>Products { get; set; }
        public DbSet<Category>Categories { get; set; }

    }
}
