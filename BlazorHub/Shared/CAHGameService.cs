namespace BlazorHub.Shared
{
    public class CAHGameService
    {
        public CAHGameService()
        {

          
        }

        public string[] ListGames()
        {
            return new string[] { "game1", "game2" };
        }

        public int GameCount()
        {
            return ListGames().Length;
        }
    }
}
