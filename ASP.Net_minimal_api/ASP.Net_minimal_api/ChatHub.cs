using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;

namespace ASP.Net_minimal_api
{
    public class ChatHub : Hub
    {
        public ConcurrentDictionary<string, string> ConnectionToUser {  get; set; }
        public ConcurrentDictionary<string, string> ConnectionToRoom { get; set; }

        public async Task Get(string message, string connectionId)
        {
            if (ConnectionToRoom.TryGetValue(connectionId, out var room) && ConnectionToUser.TryGetValue(connectionId, out var user))
            {
                // Отправка данных клиентам в определенной группе
                await Clients.Group(room).SendAsync("ReceiveMessage", user, message);
            }
        }

        public async Task Send(string message, string connectionId)
        {
            if (ConnectionToRoom.TryGetValue(connectionId, out var room) && ConnectionToUser.TryGetValue(connectionId, out var user))
            {
                // Отправка данных клиентам в определенной группе
                await Clients.Group(room).SendAsync("ReceiveMessage", user, message);
            }
        }

        public async Task JoinRoom(string roomName, string userName)
        {
            var connectionId = Context.ConnectionId;

            // Привязать соединение к комнате и пользователю
            ConnectionToRoom[connectionId] = roomName;
            ConnectionToUser[connectionId] = userName;
            // Добавляем соединение в группу по имени комнаты
            await Groups.AddToGroupAsync(connectionId, roomName);
        }

        //public override async Task OnDisconnectedAsync(string connectionId, string room)
        //{
        //    await Groups.RemoveFromGroupAsync(connectionId, room);
        //}
    }
}
