using Microsoft.AspNetCore.SignalR;

namespace SignalRNotificationsApi.Core
{
    public class NotifyHub : Hub<ITypedHubClient>
    {
    }
}