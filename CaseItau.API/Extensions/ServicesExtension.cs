using CaseItau.API.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using CaseItau.Application.Services;
using CaseItau.Infrastructure.Repositories;

namespace CaseItau.API.Infrastructure.Extensions
{
    public static class ServicesExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IFundoService, FundoService>();
            services.AddTransient<ITipoFundoService, TipoFundoService>();
            services.AddTransient<IFundoRepository, FundoRepository>();
            services.AddTransient<ITipoFundoRepository, TipoFundoRepository>();

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
