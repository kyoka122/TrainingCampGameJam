using Managers;
using UnityEngine;

namespace InGameManagerStates
{
    public class JumpingState:BaseInGameManager
    {
        protected override InGameState State => InGameState.Jumping;
        
        protected override void Entry()
        {
            
        }

        protected override InGameState UpdateGame()
        {
            character.UpdateHeight(Time.deltaTime);
            if (timer.IsTimeOver())
            {
                Finish();
                return InGameState.PlayUI;
            }
            
            if (character.IsFallObservable.Value)
            {
                return InGameState.FallStart;
            }
            return State;
        }

        protected override void Exit()
        {
            
        }
    }
}