using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.EntityFramework;
using Microsoft.Extensions.DependencyInjection;

namespace Business
{
    public static class ServiceRegistration
    {
        public static void AddingBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IRoomService, RoomManager>();
            services.AddScoped<IHotelService, HotelManager>();
            services.AddScoped<IReservationService, ReservationManager>();


        }
    }
}
