
using ECommerce.Application.Repositories;
using ECommerce.Persistence.Contexts;

namespace ECommerce.Persistence.Repositories.Product;

public class ProductReadRepository : ReadRepository<ECommerce.Domain.Entities.Product>, IProductReadRepository
{
    public ProductReadRepository(ECommerceDbContext context) : base(context)
    {
    }
}
