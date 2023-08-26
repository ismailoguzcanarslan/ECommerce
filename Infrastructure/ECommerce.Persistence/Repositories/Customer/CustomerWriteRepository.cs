
using ECommerce.Application.Repositories;
using ECommerce.Persistence.Contexts;

namespace ECommerce.Persistence.Repositories.Customer
{
    public class CustomerWriteRepository : WriteRepository<ECommerce.Domain.Entities.Customer>, ICustomerWriteRepository
    {
        public CustomerWriteRepository(ECommerceDbContext context) : base(context)
        {

        }
    }
}
