using Upd8.Data.Context;
using Upd8.Domain.Core.Interfaces.Repositories;
using Upd8.Domain.Entities;

namespace Upd8.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(Upd8Context context) : base(context) { }
    }
}
