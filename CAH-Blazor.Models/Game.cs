using FluentValidation;

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

    public class GameValidator : AbstractValidator<Game>
    {
        public GameValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Please enter a name");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Please enter a password");
            RuleFor(x => x.MaxPlayers).GreaterThan(2).WithMessage("3 Players or more required");
        }
    }
}