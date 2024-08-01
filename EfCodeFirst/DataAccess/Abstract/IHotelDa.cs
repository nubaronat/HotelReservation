using EfCodeFirst.Entity;
using Entity.DTOs.Hotel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IHotelDa : IGenericDa<Hotel>
    {
        // Add method for filtering hotel
        IQueryable<Hotel> GetHotels(GetHotelRequestDto filter);
    }
}
