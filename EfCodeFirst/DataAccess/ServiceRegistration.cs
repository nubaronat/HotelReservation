using DataAccess.Abstract;
using DataAccess.Concrete.Repositories;
using DataAccessLayer.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess;

public static class ServiceRegistration
{
    public static void AddPersistenceServices(this IServiceCollection services)
    {
        services.AddDbContext<Context>();
        services.AddScoped<ICustomerReadRepository,CustomerReadRepository>();
        services.AddScoped<ICustomerWriteRepository,CustomerWriteRepository>();
    } 
}
