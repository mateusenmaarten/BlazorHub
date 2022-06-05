

public class BlackCard : Card
{
    public BlackCard(Guid id, string text) : base(id, text)
    {
    }

    public int OpenSpots { get; private set; } = 1;


    
}



