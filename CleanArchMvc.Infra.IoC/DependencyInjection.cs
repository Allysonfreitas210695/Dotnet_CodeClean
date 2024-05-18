using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Mappings;
using CleanArchMvc.Application.Services;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using CleanArchMvc.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchMvc.Infra.IoC
{
    public static class DependencyInjection
    {
         public static IServiceCollection AddInfraestrutura(this IServiceCollection services, string configuration) 
        {            
            services.AddDbContext<ApplicationContext>(options => 
                options.UseSqlServer(configuration,
                    b => b.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)
                )
            );

            services.AddScoped<ICategoryRepository, CategoriyRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));
            return services;
        }
    }
}