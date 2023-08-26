
using ECommerce.Application.Repositories;
using ECommerce.Persistence.Contexts;

namespace ECommerce.Persistence.Repositories.Order;

public class OrderWriteRepository : WriteRepository<ECommerce.Domain.Entities.Order>, IOrderWriteRepository
{
    public OrderWriteRepository(ECommerceDbContext context) : base(context)
    {

    }
}
