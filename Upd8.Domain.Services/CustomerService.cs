using AutoMapper;
using Upd8.Domain.Core.Interfaces.Repositories;
using Upd8.Domain.Core.Interfaces.Services;
using Upd8.Domain.Dtos;
using Upd8.Domain.Entities;

namespace Upd8.Domain.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public Customer Add(NewCustomerDto customer)
        {
            var newCustomer = _mapper.Map<Customer>(customer);

            return _customerRepository.Add(newCustomer);
        }

        public Customer Delete(long id)
        {
            var customer = _customerRepository.GetById(id)
                ?? throw new Exception($"Não foi possível identificar o cliente de Id {id}");

            customer.IsDeleted = true;
            customer.UpdatedAt = DateTime.UtcNow;

            return _customerRepository.Update(customer);
        }

        public Customer[] GetAll()
            => _customerRepository.GetAll()
                                  .Where(c => !c.IsDeleted)
                                  .ToArray();

        public Customer? GetById(long id)
            => _customerRepository.GetById(id);

        public Customer Update(EditCustomerDto customer)
        {
            var customerEditted = _customerRepository.GetById(customer.Id)
                ?? throw new Exception($"Não foi possível identificar o cliente de Id {customer.Id}");

            customerEditted.Cpf = customer.Cpf ?? customerEditted.Cpf;
            customerEditted.Name = customer.Name ?? customerEditted.Name;
            customerEditted.Birthday = customer.Birthday ?? customerEditted.Birthday;
            customerEditted.Gender = customer.Gender ?? customerEditted.Gender;
            customerEditted.Address = customer.Address ?? customerEditted.Address;
            customerEditted.State = customer.State ?? customerEditted.State;
            customerEditted.City = customer.City ?? customerEditted.City;
            customerEditted.UpdatedAt = DateTime.UtcNow;

            return _customerRepository.Update(customerEditted);
        }
    }
}