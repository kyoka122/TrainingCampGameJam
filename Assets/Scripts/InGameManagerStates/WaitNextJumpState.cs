using Managers;
using UnityEngine;

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
            timer.UpdateTimer();
            if (timer.IsTimeOver())
            {
                Finish();
                return InGameState.PlayUI;
            }
            
            character.UpdateHeight(Time.deltaTime);
            
            
            if (OverBorderline())
            {
                Jump();
                return InGameState.Jumping;
            }

            return State;
        }

        protected override void Exit()
        {
            
        }
        
        private void Jump()
        {
            character.Jump(jumpPower);
            borderLineView.SetActive(false);
        }
    }
}