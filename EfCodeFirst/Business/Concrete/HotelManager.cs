using Business.Abstract;
using EfCodeFirst.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class HotelManager : IHotelService
    {
        public void TDelete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Hotel> TGetAll()
        {
            throw new NotImplementedException();
        }

        public void TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void TInsert(Hotel entity)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Hotel entity)
        {
            throw new NotImplementedException();
        }
    }
}
