using Microsoft.AspNetCore.SignalR;
namespace Loogan.Web.UI.Utilities;

/// <summary>
/// 
/// </summary>
public class ChatHub : Hub
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="user"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    public async Task SendMessage(string user, string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }
}

