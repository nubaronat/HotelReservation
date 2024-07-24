using DataAccess.Abstract;
using DataAccessLayer.Concrete;
using EfCodeFirst.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Repositories
{
    internal class ReservationReadRepository : ReadRepository<Reservation>, IReservaitonReadRepository
    {
        public ReservationReadRepository(Context context) : base(context)
        {
        }
    }
}
