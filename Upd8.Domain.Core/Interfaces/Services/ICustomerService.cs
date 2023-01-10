using Upd8.Domain.Dtos;
using Upd8.Domain.Entities;

namespace Upd8.Domain.Core.Interfaces.Services
{
    public interface ICustomerService
    {
        public Customer Add(NewCustomerDto customer);
        public Customer Delete(long id);
        public Customer[] GetAll();
        public Customer? GetById(long id);
        public Customer Update(EditCustomerDto customer);
    }
}
