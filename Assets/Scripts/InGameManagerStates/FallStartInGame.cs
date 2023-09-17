using Managers;
using UnityEngine;

namespace InGameManagerStates
{
    public class FallStartInGame:BaseInGameState
    {
        protected override InGameState State => InGameState.FallStart;
        
        protected override void Entry()
        {
            BorderLine.ChangeBorderLineHeight(Character,BorderLineUnderLength);
        }

        protected override InGameState UpdateGame()
        {
            Character.UpdateHeight(Time.deltaTime);
            if (Timer.IsTimeOver())
            {
                Finish();
                return InGameState.PlayUI;
            }
            
            if (OverBorderline())
            {
                Debug.LogError($"ボーダーライン表示前にボーダーラインを超えています。");
                GameOver();
                return InGameState.PlayUI;
            }

            if (Character.HeightObservable.Value < BorderLine.HeightObservable.Value + BorderLineDisplayLength)
            {
                ActiveJumpCard();
                //ActiveBoarderLine();
                return InGameState.WaitClick;
            }

            return State;
        }

        private void ActiveJumpCard()
        {
            Spawner.SetCard();
        }
        
        /*private void ActiveBoarderLine()
        {
            BorderLineView.SetActive(true);
        }*/

        protected override void Exit()
        {
            
        }
    }
}