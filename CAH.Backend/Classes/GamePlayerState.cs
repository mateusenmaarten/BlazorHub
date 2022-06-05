public class GamePlayerState
{
    public GamePlayerState()
    {
        this.Hand = new Hand(new List<WhiteCard>());
        PlayerScore = 0;
    }

    public Hand Hand { get; set; }
    public int PlayerScore { get; set; } 
}