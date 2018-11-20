using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignalRNotificationsApi.Core
{
    public interface ICustomerRepository
    {
        Task Add(Customer customer);

        Task<IReadOnlyCollection<Customer>> Get();
        Task<Customer> Get(Guid id);
    }
}