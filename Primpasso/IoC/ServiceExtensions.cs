using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Primpasso.Context;

namespace Primpasso.IoC
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddSQLDatabase(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<PrimpassoDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            return service;
        }
    }
}
