using CAH.Data.Factories;
using CAH.Data.Interfaces;

namespace CAH.Backend.Factories
{
   
    public class BlackDeckFactory : DeckFactory<BlackCard> {

        public BlackDeckFactory() : base() { 
        

        }

        public override BlackDeck CreateDeck()
        {
            List<string> allQuestions = Reader.GetAllQuestions();
            List<BlackCard> createdBlackDeckCards = new List<BlackCard>();
            foreach (var line in allQuestions)
            {
                BlackCard newCard = new BlackCard(Guid.NewGuid(), line);
                createdBlackDeckCards.Add(newCard);
            }

            return new BlackDeck(createdBlackDeckCards);
        }

    }
}