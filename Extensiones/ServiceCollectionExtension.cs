using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using uttt.Micro.Libro.Aplicacion;
using uttt.Micro.Libro.Persistencia;
using MediatR;
using AutoMapper;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;  



namespace uttt.Micro.Libro.Extensiones
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers()
                .AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<Nuevo>());

            services.AddDbContext<ContextoLibreria>(options =>
            {
                options.UseMySql(
                   configuration.GetConnectionString("DefaultConnection"),
                   ServerVersion.AutoDetect(configuration.GetConnectionString("DefaultConnection"))
               );
            });

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Nuevo.Manejador>());

            services.AddAutoMapper(typeof(Consulta.Manejador));

            return services;
        }

    }
}
