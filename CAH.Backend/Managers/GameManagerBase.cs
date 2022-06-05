using CAH.Backend.Classes;
using CAH.Backend.Interfaces;

namespace CAH.Backend.Managers
{
    public abstract class GameManagerBase
    {
        public abstract void StartGame();

        public abstract void DealPlayerHands();

        public abstract void DrawOpeningHand(IGamePlayer player);

        public abstract void EndGame();

        public abstract void SetTurnState(TurnState turnstate);

        public abstract TurnState GetCurrentGameState();
    }
}
