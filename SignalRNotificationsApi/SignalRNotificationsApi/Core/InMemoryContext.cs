using System.Collections.ObjectModel;

namespace SignalRNotificationsApi.Core
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