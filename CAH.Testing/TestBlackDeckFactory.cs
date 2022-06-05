using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAH.Testing
{
    internal class TestBlackDeckFactory : CAH.Backend.Factories.BlackDeckFactory
    {
        private List<BlackCard> _cards = new List<BlackCard>();
        public override BlackDeck CreateDeck()
        {
            for (int i = 0; i < 10; i++)
            {
                _cards.Add(new BlackCard(Guid.NewGuid(), $"BlackCard {i}"));
            }
            
            return new BlackDeck(_cards);
        }
    }
}
