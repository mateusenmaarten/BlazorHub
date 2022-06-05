using System.Xml.Linq;
using System.Xml;
using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CAH.Backend.Interfaces;

namespace CAH.Testing
{
    public class FakePlayer : IPlayer 
    {
        public FakePlayer() {


        }

        public Guid ID {get;set;}
        public string Name {get;set;}
        public int Score {get;set;}
        public GamePlayerState PlayerState {get;set;}

        Random r = new Random();

        public WhiteCard PlayWhiteCard()  {

            int index = r.Next(0, PlayerState.Hand.CardsInHand.Count());
            
            var card = PlayerState.Hand.Remove(index);

            return card;
        }

        public WhiteCard SelectWinningWhiteCard(IEnumerable<WhiteCard> whitecards)
        {
            int randomIndex = r.Next(0, whitecards.Count());
            
            return whitecards.Skip(randomIndex).First();
        }
    }
}