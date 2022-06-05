using CAH.Backend.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAH.Backend.Classes
{
    public class GamePlayer : IGamePlayer
    {
        private IPlayer _player;
        public GamePlayer(IPlayer player)
        {
            _player = player;
            PlayerState = new GamePlayerState();
        }

        public GamePlayerState PlayerState { get; set; } 
        public IPlayer Player => _player;

        public WhiteCard PlayWhiteCard()
        {
            throw new NotImplementedException();
        }

        public WhiteCard SelectWinningWhiteCard(IEnumerable<WhiteCard> whitecards)
        {
            throw new NotImplementedException();
        }
    }
}
