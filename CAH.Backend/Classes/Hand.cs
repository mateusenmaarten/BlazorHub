

using CAH.Backend.Exceptions;

public class Hand
{

    // max 10 cards

    private List<WhiteCard> cards = new List<WhiteCard>();
    public IEnumerable<WhiteCard> CardsInHand => cards;

    public Hand(IEnumerable<WhiteCard> _cards)
    {
        this.Add(cards);
    }

    public void Add(IEnumerable<WhiteCard> cards)
    {
        this.cards.AddRange(cards);
    }

    public void Add(WhiteCard c)
    {

        if (cards.Count > 10)
        {
            throw new PlayerException("Hand full (max 10)");
        }

        cards.Add(c);
    }


    public WhiteCard Remove(int i){

        if(cards.Count <= i){
            throw new PlayerException("Index out of range on card hand count");
        }

        var card = cards[i];

        return this.Remove(card);

        
    }

    public WhiteCard Remove(WhiteCard c)
    {
        if (cards.Contains(c))
        {
            cards.Remove(c);

            return c;
        }
        else
        {
            throw new PlayerException("Card is not in hand");
        }
    }

}



