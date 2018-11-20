using System.Threading.Tasks;

namespace SignalRNotificationsApi.Core
{
    public interface ITypedHubClient
    {
        Task BroadcastMessage(string message);
    }
}