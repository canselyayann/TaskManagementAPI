using Microsoft.AspNetCore.SignalR;

namespace TaskManagementAPI.Hubs
{
    public class TaskHub : Hub
    {
        // Görev durumunu güncelleyen bir metot
        public async Task SendTaskUpdate(string taskId, string taskStatus)
        {
            // Burada tüm baðlý istemcilere mesaj gönderebiliriz
            await Clients.All.SendAsync("ReceiveTaskUpdate", taskId, taskStatus);
        }

        // Ýstemciye mesaj gönderen bir metot
        public async Task SendMessageToUser(string userId, string message)
        {
            await Clients.User(userId).SendAsync("ReceiveMessage", message);
        }
    }
}
