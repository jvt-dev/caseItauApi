using CaseItau.API.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CaseItau.API.Infrastructure.Extensions
{
    public static class DataBaseContextExtension
    {
        public static IServiceCollection AddDatabaseContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FundoContext>(
                options => options.UseSqlite(configuration.GetConnectionString("DataBase")));

            return services;
        }
    }
}
