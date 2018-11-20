using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SignalRNotifications.Hubs
{
    public class NotifyHub : Hub
    {
        public Task Notify(string message)
        {
            return Clients.All.SendAsync("Notify", message);
        }
    }
}