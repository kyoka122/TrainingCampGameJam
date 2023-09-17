namespace Managers.InGameManagerStates
{
    public class FallingState:BaseInGameManager
    {
        protected override InGameState State => InGameState.Falling;
        
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