using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
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
			string userId = Context.User.Claims.First().Value;

			if(ConnectedUsers.ContainsKey(userId))
			{
				ConnectedUsers[userId] = connectionId;
			}
			else
			{
				ConnectedUsers.TryAdd(userId, connectionId);
			}

			await base.OnConnectedAsync();
		}

		public async override Task OnDisconnectedAsync(Exception ex)
		{
			ConnectedUsers.TryRemove(Context.ConnectionId, out string result);

			await base.OnDisconnectedAsync(ex);
		}
		public async Task SendMessage(string user, string message, string avatar, string friends)
        {
			List<string> usersToSend = JsonConvert.DeserializeObject<List<string>>(friends);
			List<string> ids = ConnectedUsers.Where(x => usersToSend.Contains(x.Key)).Select(x => x.Value).ToList();

			await Clients.Clients(ids).SendAsync("ReceiveMessage", user, message, avatar);
        }
    }
}
