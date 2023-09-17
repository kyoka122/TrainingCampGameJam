﻿using Managers;

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
            if ()//最高点に到達
            {
                return InGameState.WaitChooseCard;
            }
            return State;
        }

        protected override void Exit()
        {
            
        }
    }
}