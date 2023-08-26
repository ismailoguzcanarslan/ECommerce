using ECommerce.Application.Repositories;
using ECommerce.Persistence.Contexts;
using ECommerce.Persistence.Repositories.Customer;
using ECommerce.Persistence.Repositories.Order;
using ECommerce.Persistence.Repositories.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Persistence;

public static class ServiceRegistration
{
    public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ECommerceDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("Postgres")));

        services.AddScoped<IProductReadRepository, ProductReadRepository>();
        services.AddScoped<IProductWriteRepository, ProductWriteRepository>();

        services.AddScoped<IOrderReadRepository, OrderReadRepository>();
        services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();

        services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
        services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
    }
}
