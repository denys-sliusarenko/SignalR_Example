using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace SignalR_Example.Hubs
{
    public class ChatHub : Hub
    {
        public async Task Send(string message)
        {
            await Clients.All.SendAsync("Receive", message, Context.ConnectionId);
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("Notify", $"{Context.ConnectionId} joined chat");
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Clients.All.SendAsync("Notify", $"{Context.ConnectionId} left chat");
            await base.OnDisconnectedAsync(exception);
        }
    }
}