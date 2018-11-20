using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SignalRNotifications.Models;

namespace SignalRNotifications.Infra
{
    public interface ICustomerRepository
    {
        Task Add(Customer customer);

        Task<IReadOnlyCollection<Customer>> Get();
        Task<Customer> Get(Guid id);
    }
}