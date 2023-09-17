using Managers;

namespace InGameManagerStates
{
    public class WaitNextJumpState:BaseInGameManager
    {
        protected override InGameState State => InGameState.WaitNextJump;
        protected override void Entry()
        {
            
        }

        protected override InGameState UpdateGame()
        {
            if (IsReachBorderLine())
            {
                Jump();
                return InGameState.Jumping;
            }

            return State;
        }

        private bool IsReachBorderLine()
        {
            
        }

        protected override void Exit()
        {
            
        }
    }
}