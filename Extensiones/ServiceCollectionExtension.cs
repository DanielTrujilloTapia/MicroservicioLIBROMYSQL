using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using uttt.Micro.Libro.Aplicacion;
using uttt.Micro.Libro.Persistencia;
using MediatR;
using AutoMapper;


namespace uttt.Micro.Libro.Extensiones
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services, string writeConnection, string readConnection)
        {
            services.AddControllers()
                .AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<Nuevo>());

            services.AddDbContext<ContextoLibreria>(options =>
            {
                options.UseMySql(writeConnection, ServerVersion.AutoDetect(writeConnection));
            });

            services.AddDbContext<ContextoLibreriaDbGlobal>(options =>
            {
                options.UseMySql(readConnection, ServerVersion.AutoDetect(readConnection));
            });

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Nuevo.Manejador>());

            services.AddAutoMapper(typeof(Consulta.Manejador));

            return services;
        }

    }
}