using System.Collections.ObjectModel;
using SignalRNotificationsApi.Models;

namespace SignalRNotificationsApi.Infra
{
    public sealed class InMemoryContext
    {
        public InMemoryContext()
        {
            Customers = new Collection<Customer>();
        }

        public Collection<Customer> Customers { get; set; }
    }
}