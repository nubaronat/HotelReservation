using DataAccess.Abstract;
using DataAccess.Repository;
using DataAccessLayer.Concrete;
using EfCodeFirst.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
    public class EfReservationDa : GenericRepository<Reservation>, IReservationDa
    {
        public EfReservationDa(Context context) : base(context)
        {
        }
    }
}
