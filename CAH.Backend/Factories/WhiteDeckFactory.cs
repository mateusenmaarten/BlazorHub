using CAH.Data.Factories;
using CAH.Data.Interfaces;

namespace CAH.Backend.Factories
{
    public class WhiteDeckFactory : DeckFactory<WhiteCard> {

        public WhiteDeckFactory() : base() {  }

        public override WhiteDeck CreateDeck()
        {
            List<string> allAnswersFromTextFile = Reader.GetAllAnswers();
            List<WhiteCard> createdWhiteDeckCards = new List<WhiteCard>();
            foreach (var line in allAnswersFromTextFile)
            {
                WhiteCard newCard = new WhiteCard(Guid.NewGuid(), line);
                createdWhiteDeckCards.Add(newCard);
            }

            WhiteDeck whiteDeck = new WhiteDeck(createdWhiteDeckCards);

            return whiteDeck;
        }

    }
}