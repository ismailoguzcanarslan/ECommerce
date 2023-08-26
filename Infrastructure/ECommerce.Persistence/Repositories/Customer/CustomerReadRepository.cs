using ECommerce.Application.Repositories;
using ECommerce.Persistence.Contexts;

namespace ECommerce.Persistence.Repositories.Customer;

public class CustomerReadRepository : ReadRepository<ECommerce.Domain.Entities.Customer>, ICustomerReadRepository
{
    public CustomerReadRepository(ECommerceDbContext context) : base(context)
    {

    }
}
