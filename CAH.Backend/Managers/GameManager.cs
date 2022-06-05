using CAH.Backend.Classes;
using CAH.Backend.Factories;
using CAH.Backend.Interfaces;
using CAH.Backend.Managers;

public class GameManager : GameManagerBase
{
    private readonly Game _game;

    private int currentPlayerIndex=-1;
    public GameManager(Game game){
        _game = game;

    }



    public void StartNewTurn(){
        currentPlayerIndex = (currentPlayerIndex + 1) % _game.GamePlayers.Count();



        _game.GameState.CurrentBlackCardPlayer = _game.GamePlayers.ToList()[currentPlayerIndex];

        SetTurnState(TurnState.WaitingForBlackPlayerSelection);


        _game.GameState.CurrentBlackCard = _game.BlackDeck.DrawCard();

        SetTurnState(TurnState.TurnStart);
    }

    public void HandleTurn(){

        SetTurnState(TurnState.WaitingForWhitePlayerSelection);

        var whiteCardPlayers = _game.GamePlayers.Where(p => p != _game.GameState.CurrentBlackCardPlayer);

        var whiteCardsWithPlayers = whiteCardPlayers.ToDictionary<IGamePlayer, WhiteCard>((p) => p.PlayWhiteCard());

        var whiteCards = whiteCardsWithPlayers.Keys.ToList();

        SetTurnState(TurnState.WaitingForWinningCardSelection);

        var selectedWhiteCard = _game.GameState.CurrentBlackCardPlayer.SelectWinningWhiteCard(whiteCards);

        var winningPlayer = whiteCardsWithPlayers[selectedWhiteCard];

        // update player scores
        winningPlayer.PlayerState.PlayerScore++;
        

        SetTurnState(TurnState.TurnEnd);
    }

  
    public bool IsGameDone(){
        return _game.BlackDeck.Cards.Count() == 0;
    }

    
    public override void StartGame()
    {
        DealPlayerHands();
    }



    public override void DealPlayerHands()
    {
        foreach (var player in _game.GamePlayers)
        {
            DrawOpeningHand(player);
        }
    }

    public override void DrawOpeningHand(IGamePlayer player)
    {
        for (int i = 0; i < 10; i++)
        {
            var playerCard = _game.WhiteDeck.DrawCard();
            player.PlayerState.Hand.Add((WhiteCard)playerCard);
        }
    }

    public override void EndGame()
    {

    }

    public override void SetTurnState(TurnState turnstate)
    {
        _game.GameState.TurnState = turnstate;
    }

    public override TurnState GetCurrentGameState()
    {
        return _game.GameState.TurnState;
    }

}