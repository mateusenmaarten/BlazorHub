namespace CAH_Blazor.Models
{
    public class Game
    {
        public Game()
        {

        }

        public Game(string name, int maxPlayers)
        {
            Id = Guid.NewGuid();
            Name = name;
            MaxPlayers = maxPlayers;
        }

        public Game(string name, int maxPlayers, string pwd)
        {
            Id = Guid.NewGuid();
            Name = name;
            MaxPlayers = maxPlayers;
            Password = pwd;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int MaxPlayers { get; set; }
        public string Password { get; set; }
    }
}