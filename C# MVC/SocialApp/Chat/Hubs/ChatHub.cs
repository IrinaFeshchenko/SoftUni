using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Hubs
{
    public class ChatHub : Hub
    {
		public static ConcurrentDictionary<string, string> ConnectedUsers = new ConcurrentDictionary<string, string>();

		public async override Task OnConnectedAsync()
		{
			string connectionId = Context.ConnectionId;
			string userName = Context.User.Identity.Name;

			ConnectedUsers.TryAdd(connectionId, userName);
			await base.OnConnectedAsync();
		}

		public async override Task OnDisconnectedAsync(Exception ex)
		{
			ConnectedUsers.TryRemove(Context.ConnectionId, out string result);

			await base.OnDisconnectedAsync(ex);
		}
		public async Task SendMessage(string user, string message, string avatar, string friends)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message, avatar);

        }
    }
}
