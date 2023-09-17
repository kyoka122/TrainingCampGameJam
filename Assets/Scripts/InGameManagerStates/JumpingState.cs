namespace Managers.InGameManagerStates
{
    public class JumpingState:BaseInGameManager
    {
        protected override InGameState State => InGameState.Jumping;
        
        protected override void Entry()
        {
            Jump();
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