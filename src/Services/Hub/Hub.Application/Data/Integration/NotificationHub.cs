using Microsoft.AspNetCore.SignalR;

namespace Hub.Application.Data.Integration
{
    public class NotificationHub : Microsoft.AspNetCore.SignalR.Hub
    {
        private static readonly Dictionary<string, string> userConnections = new();

        public override async Task OnConnectedAsync()
        {
            var userId = Context.UserIdentifier;
            if (!string.IsNullOrEmpty(userId))
            {
                userConnections[userId] = Context.ConnectionId;
            }

            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var userId = Context.UserIdentifier;
            if (!string.IsNullOrEmpty(userId))
            {
                userConnections.Remove(userId);
            }

            await base.OnDisconnectedAsync(exception);
        }

        public async Task SendPrizeNotification(string userId, string message)
        {
            if (userConnections.ContainsKey(userId))
            {
                var connectionId = userConnections[userId];
                await Clients.Client(connectionId).SendAsync("ReceivePrizeNotification", message);
            }
        }
    }
}
