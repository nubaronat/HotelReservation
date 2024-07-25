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
    public class EfRoomDa : GenericRepository<Room>, IRoomDa
    {
        public EfRoomDa(Context context) : base(context)
        {
        }
    }
}
