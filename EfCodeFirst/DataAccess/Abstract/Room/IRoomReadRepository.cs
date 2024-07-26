using DataAccess.Abstract;
using EfCodeFirst.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IRoomReadRepository : IReadRepository<Room>
    {
    }
}
