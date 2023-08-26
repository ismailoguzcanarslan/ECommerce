using ECommerce.Application.Repositories;
using ECommerce.Persistence.Contexts;

namespace ECommerce.Persistence.Repositories.Order;

public class OrderReadRepository : ReadRepository<ECommerce.Domain.Entities.Order>, IOrderReadRepository
{
    public OrderReadRepository(ECommerceDbContext context) : base(context)
    {

    }
}
