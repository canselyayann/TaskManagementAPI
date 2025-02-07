using Microsoft.AspNetCore.SignalR;

namespace TaskManagementAPI.Hubs
{
    public class TaskHub : Hub
    {
        // G�rev durumunu g�ncelleyen bir metot
        public async Task SendTaskUpdate(string taskId, string taskStatus)
        {
            // Burada t�m ba�l� istemcilere mesaj g�nderebiliriz
            await Clients.All.SendAsync("ReceiveTaskUpdate", taskId, taskStatus);
        }

        // �stemciye mesaj g�nderen bir metot
        public async Task SendMessageToUser(string userId, string message)
        {
            await Clients.User(userId).SendAsync("ReceiveMessage", message);
        }
    }
}
