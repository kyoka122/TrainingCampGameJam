using Managers;

namespace InGameManagerStates
{
    public class PlayingUIState:BaseInGameManager
    {
        protected override InGameState State => InGameState.PlayUI;
        protected override void Entry()
        {
            
        }

        protected override InGameState UpdateGame()
        {
            return State;
        }

        protected override void Exit()
        {
            
        }
    }
}