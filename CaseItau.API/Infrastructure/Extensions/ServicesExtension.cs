using CaseItau.API.Application.Repositories;
using CaseItau.API.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CaseItau.API.Infrastructure.Extensions
{
    public static class ServicesExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IFundoService, FundoService>();
            services.AddTransient<IFundoRepository, FundoRepository>();

            return services;
        }
    }
}
