
using CAH.Backend.Interfaces;

namespace CAH.Backend.Classes
{
    public interface IGamePlayer
    {
        IPlayer Player { get; }
        GamePlayerState PlayerState { get; set; }
        WhiteCard PlayWhiteCard();
        WhiteCard SelectWinningWhiteCard(IEnumerable<WhiteCard> whitecards);
    }
}