using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SignalRNotifications.Models;

namespace SignalRNotifications.Infra
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly InMemoryContext _inMemoryContext;

        public CustomerRepository(InMemoryContext inMemoryContext)
        {
            _inMemoryContext = inMemoryContext;
        }

        public async Task Add(Customer customer)
        {
            _inMemoryContext.Customers.Add(customer);

            await Task.CompletedTask;
        }

        public async Task<IReadOnlyCollection<Customer>> Get()
        {
            return await Task.FromResult(_inMemoryContext.Customers);
        }

        public async Task<Customer> Get(Guid id)
        {
            return await Task.FromResult(_inMemoryContext.Customers.SingleOrDefault(x => x.Id == id));
        }
    }
}