using Managers;
using UnityEngine;

namespace InGameManagerStates
{
    public class FallStartState:BaseInGameManager
    {
        protected override InGameState State => InGameState.FallStart;
        
        protected override void Entry()
        {
            
        }

        protected override InGameState UpdateGame()
        {
            if (OverBorderline())
            {
                Debug.LogError($"ボーダーライン表示前にボーダーラインを超えています。");
                return InGameState.OverBoarderLine;
            }
            if ()//基底秒数たったらカードとボーダーライン表示。
            {
                ActiveJumpCard();
                ActiveBoarderLine();
                return InGameState.WaitClick;
            }
            return State;
        }

        private void ActiveBoarderLine()
        {
            
        }

        protected override void Exit()
        {
            
        }
    }
}