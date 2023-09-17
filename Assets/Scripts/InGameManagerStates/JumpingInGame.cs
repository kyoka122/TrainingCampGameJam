using Managers;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace InGameManagerStates
{
    public class JumpingInGame:BaseInGameState
    {
        protected override InGameState State => InGameState.Jumping;

        
        protected override void Entry()
        {
            
        }

        protected override InGameState UpdateGame()
        {
            Timer.UpdateTimer();
            Character.UpdateHeight(Time.deltaTime);
            if (Timer.IsTimeOver())
            {
                Finish();
                return InGameState.PlayUI;
            }
            
            if (Character.IsFallObservable.Value)
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