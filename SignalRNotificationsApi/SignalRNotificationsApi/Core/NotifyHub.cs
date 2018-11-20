using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SignalRNotificationsApi.Core
{
    public class NotifyHub : Hub
    {
        public Task Notify(string message)
        {
            return Clients.All.SendAsync("Notify", message);
        }
    }
}