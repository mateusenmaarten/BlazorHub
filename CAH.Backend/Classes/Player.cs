using CAH.Backend.Interfaces;

public class Player : IPlayer
{
    public Guid ID { get; set; } = Guid.Empty;
    public string Name { get; set; } = String.Empty;
    
  

    public WhiteCard PlayWhiteCard()
    {
        throw new NotImplementedException();
    }

    public WhiteCard SelectWinningWhiteCard(IEnumerable<WhiteCard> whitecards)
    {
        throw new NotImplementedException();
    }
}