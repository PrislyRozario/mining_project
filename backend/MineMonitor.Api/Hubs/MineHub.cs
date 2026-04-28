using Microsoft.AspNetCore.SignalR;

namespace MineMonitor.Api.Hubs;

public class MineHub : Hub
{
    public override async Task OnConnectedAsync()
    {
        Console.WriteLine($"Mine dashboard connected: {Context.ConnectionId}");
        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        Console.WriteLine($"Mine dashboard disconnected: {Context.ConnectionId}");
        await base.OnDisconnectedAsync(exception);
    }
}
