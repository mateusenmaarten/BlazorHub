using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;

namespace BlazorHub.Shared
{


    public class ChatContext
    {


        public ChatContext(Guid g, NavigationManager navigationManager) {
            this.guid = g;
            this.navigationManager = navigationManager;
        }

        // flag to indicate chat status
        public bool IsChatting = false;

        // name of the user who will be chatting
        //public string UserName { get; set; }

        // on-screen message
        public string Message { get; set; }

        // new message input
        public string NewMessage { get; set; }

        // list of messages in chat
        public List<Message> Messages = new List<Message>();

        private string _hubUrl;
        private HubConnection _hubConnection;
        private Guid guid;
        private UserContext uc;
        private readonly NavigationManager navigationManager;

        public event EventHandler ChatMessagesUpdated;

        public void Login(UserContext uc) {
            this.uc = uc;
        }

        public async Task Chat()
        {
            // check username is valid


            try
            {
                // Start chatting and force refresh UI.
                IsChatting = true;
                await Task.Delay(1);

                // remove old messages if any
                Messages.Clear();

                // Create the chat client
                string baseUrl = navigationManager.BaseUri;

                _hubUrl = baseUrl.TrimEnd('/') + BlazorChatSampleHub.HubUrl;

                _hubConnection = new HubConnectionBuilder()
                    .WithUrl(_hubUrl)
                    .Build();

                _hubConnection.On<string, string>("Broadcast", BroadcastMessage);

                await _hubConnection.StartAsync();

                NewMessage = $"[Notice] {uc.UserName} joined chat room.";

                await SendAsync();
            }
            catch (Exception e)
            {
                Message = $"ERROR: Failed to start chat client: {e.Message}";
                IsChatting = false;
            }
        }

        public void BroadcastMessage(string name, string message)
        {
            bool isMine = name.Equals(uc.UserName, StringComparison.OrdinalIgnoreCase);

            Messages.Add(new Message(name, message, isMine));

            // Inform blazor the UI needs updating
            ChatMessagesUpdated.Invoke(this, null);
        }

        //public event EventHandler StateHasChanged;

        public async Task DisconnectAsync()
        {
            if (IsChatting)
            {
                NewMessage = $"[Notice] {uc.UserName} left chat room.";
                await SendAsync();

                await _hubConnection.StopAsync();
                await _hubConnection.DisposeAsync();

                _hubConnection = null;
                IsChatting = false;
            }
        }

        public async Task SendAsync()
        {
            if (IsChatting && !string.IsNullOrWhiteSpace(NewMessage))
            {
                await _hubConnection.SendAsync("Broadcast", uc.UserName, NewMessage);

                NewMessage = string.Empty;
            }
        }

        
    }

    public class Message
    {
        public Message(string UserName, string body, bool mine)
        {
            UserName = UserName;
            Body = body;
            Mine = mine;
        }

        public string UserName { get; set; }
        public string Body { get; set; }
        public bool Mine { get; set; }

        public bool IsNotice => Body.StartsWith("[Notice]");

        public string CSS => Mine ? "sent" : "received";
    }
}
