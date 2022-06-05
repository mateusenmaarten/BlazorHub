

using CAH.Backend.Exceptions;

public abstract class Deck<T>
    where T : Card
{
    public Deck(IEnumerable<T> cards)
    {
        this.cards = new List<T>(cards);
    }
    public IEnumerable<T> Cards => cards;
    private List<T> cards;
    public T DrawCard()
    {
        return DrawCard(0);
    }

    public T DrawCard(int index){

        if(index >= this.cards.Count){
            throw new DeckException($"Index ({index}) is higher than number of cards ({this.cards.Count})");
        }

        var cardDrawn = cards[index];
        cards.RemoveAt(index);
        return cardDrawn;

    }

    public void Shuffle()
    {
        cards = Cards.OrderBy(c => Guid.NewGuid()).ToList();
    }
}



