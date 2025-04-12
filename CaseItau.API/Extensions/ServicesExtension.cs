using CaseItau.API.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using CaseItau.Application.Services;

namespace CaseItau.API.Infrastructure.Extensions
{
    public static class ServicesExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IFundoService, FundoService>();
            services.AddTransient<IFundoRepository, FundoRepository>();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            return services;
        }
    }
}
