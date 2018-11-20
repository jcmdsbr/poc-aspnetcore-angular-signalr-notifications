using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SignalRNotificationsApi.Models;

namespace SignalRNotificationsApi.Infra
{
    public interface ICustomerRepository
    {
        Task Add(Customer customer);

        Task<IReadOnlyCollection<Customer>> Get();
        Task<Customer> Get(Guid id);
    }
}