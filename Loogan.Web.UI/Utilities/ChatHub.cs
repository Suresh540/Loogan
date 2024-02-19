using Loogan.API.Database.Models;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System;
namespace Loogan.Web.UI.Utilities;

/// <summary>
/// Chathub library
/// </summary>
public class ChatHub : Hub
{
    /// <summary>
    /// Connection
    /// </summary>
    /// <returns></returns>
    public override async Task OnConnectedAsync()
    {
        var userId = Context?.User?.Identity?.Name;
        await Groups.AddToGroupAsync(Context.ConnectionId, userId);
        await base.OnConnectedAsync();
    }

    /// <summary>
    /// Disconnection
    /// </summary>
    /// <param name="exception"></param>
    /// <returns></returns>
    public override async Task OnDisconnectedAsync(Exception ex)
    {
        var userId = Context?.User?.Identity?.Name;
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, userId);
        await base.OnDisconnectedAsync(ex);
    }

    public Task SendMessageToGroup(string groupname, string sender, string message)
    {
        return Clients.Group(groupname).SendAsync("ReceiveMessage", sender, message);
    }
}

