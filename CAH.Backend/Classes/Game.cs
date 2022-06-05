using System.Net.NetworkInformation;
using CAH.Backend.Classes;
using CAH.Backend.Interfaces;

public class Game
{

    public Game(BlackDeck blackDeck, WhiteDeck whiteDeck, IEnumerable<IGamePlayer> gamePlayers)
    {
        // fixed properties
        BlackDeck = blackDeck;
        WhiteDeck = whiteDeck;
        GamePlayers = gamePlayers;
        // state mgmt
        PlayersWithState = new Dictionary<Player, GamePlayerState>();
        GameState = new GameState();

        // game manager
        GameManager = new GameManager(this);
    }



    public GameManager GameManager {get; private set;}

    public Guid ID { get;  } = Guid.NewGuid();
    public GameState GameState { get; private set; }
    public IEnumerable<IGamePlayer> GamePlayers {get;}
    public Dictionary<Player,GamePlayerState> PlayersWithState { get; set; }
    public BlackDeck BlackDeck { get; set; }
    public WhiteDeck WhiteDeck { get; set; }

}

