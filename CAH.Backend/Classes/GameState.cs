using CAH.Backend.Classes;
using CAH.Backend.Interfaces;

public class GameState
{
    public TurnState TurnState { get; set; }
    public Dictionary<IGamePlayer, GamePlayerState> PlayerStates { get; set; }
    
    public IGamePlayer CurrentBlackCardPlayer { get; set; }
    public BlackCard CurrentBlackCard { get; set; }
    
    // public IEnumerable<BlackCard> PlayedBlackCards { get; set; }
    // public IEnumerable<WhiteCard> PlayedWhiteCards { get; set; }
}


