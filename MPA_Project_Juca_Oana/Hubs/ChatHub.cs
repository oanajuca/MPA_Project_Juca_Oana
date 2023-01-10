using Microsoft.AspNetCore.SignalR;

namespace MPA_Project_Juca_Oana.Hubs
{
    public class ChatHub :Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
