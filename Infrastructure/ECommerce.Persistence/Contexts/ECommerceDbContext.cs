using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Persistence.Contexts;

public class ECommerceDbContext : DbContext
{
    public ECommerceDbContext(DbContextOptions options) : base(options)
    { }

    public DbSet<Order> Orders { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Product> Products { get; set; }

}
