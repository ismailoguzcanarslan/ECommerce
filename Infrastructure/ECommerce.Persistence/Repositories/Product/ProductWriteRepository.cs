using ECommerce.Application.Repositories;
using ECommerce.Persistence.Contexts;

namespace ECommerce.Persistence.Repositories.Product;

public class ProductWriteRepository : WriteRepository<ECommerce.Domain.Entities.Product>, IProductWriteRepository
{
    public ProductWriteRepository(ECommerceDbContext context) : base(context)
    {

    }
}
