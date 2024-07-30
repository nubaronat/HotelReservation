using EfCodeFirst.Entity;
using Entity.DTOs.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IReservationDa : IGenericDa<Reservation>
    {
        // Add method for filtering customer
        IQueryable<Reservation> GetReservations(GetReservationRequestDto filter);
    }
}
