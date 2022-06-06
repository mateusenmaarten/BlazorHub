using static BlazorHub.Pages.NewGame;
using CAH_Blazor.Models;

namespace BlazorHub
{
    public class State
    {
        public List<Game> GamesToJoin = new List<Game>();
        public Dictionary<Guid, HashSet<string>> connectionIdPerChatGuid = new Dictionary<Guid, HashSet<string>>();
    }
}
