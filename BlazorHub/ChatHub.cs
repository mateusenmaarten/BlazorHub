using Microsoft.AspNetCore.SignalR;

namespace BlazorHub
{
    public class ChatHub : Hub
    {
        

        public const string HubUrl = "/chat";
        public async Task Broadcast(string username, string message, Guid chatGuid)
        {

            try
            {
                var targetClients = connectionIdPerChatGuid[chatGuid];

                var clients = Clients;
                var selectedClients = Clients.Clients(targetClients);

                await selectedClients.SendAsync("Broadcast", username, message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            

            //await Clients.All.SendAsync("Broadcast", username, message);
        }

        private static Dictionary<Guid, HashSet<string>> connectionIdPerChatGuid = new Dictionary<Guid, HashSet<string>>();

        public override Task OnConnectedAsync()
        {
            string chatGuidString = Context.GetHttpContext().Request.Query["chatGuid"];
            Guid chatGuid = Guid.Parse(chatGuidString);

            Console.WriteLine($"{Context.ConnectionId} connected");

            if (!connectionIdPerChatGuid.ContainsKey(chatGuid))
            {
                connectionIdPerChatGuid.Add(chatGuid, new HashSet<string>());
            }

            connectionIdPerChatGuid[chatGuid].Add(Context.ConnectionId);

            return base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception e)
        {
            Console.WriteLine($"Disconnected {e?.Message} {Context.ConnectionId}");
            await base.OnDisconnectedAsync(e);
        }
    }
}
