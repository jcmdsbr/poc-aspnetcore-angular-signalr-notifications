using System.Collections.ObjectModel;
using SignalRNotifications.Models;

namespace SignalRNotifications.Infra
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