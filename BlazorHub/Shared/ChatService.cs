using Microsoft.AspNetCore.Components;

namespace BlazorHub.Shared
{
    public class ChatService
    {
        private Dictionary<Guid, ChatContext> _chatContexts = new Dictionary<Guid, ChatContext>();


        public ChatContext Resolve(Guid guid, NavigationManager navigationManager)
        {

            if (!_chatContexts.ContainsKey(guid)) {
                _chatContexts.Add(guid, new ChatContext(guid, navigationManager));

            }

            return _chatContexts[guid];

            
        }


    }
}
