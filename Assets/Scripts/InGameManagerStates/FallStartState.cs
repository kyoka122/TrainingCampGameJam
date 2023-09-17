using Managers;
using UnityEngine;

namespace InGameManagerStates
{
    public class FallStartState:BaseInGameManager
    {
        protected override InGameState State => InGameState.FallStart;
        
        protected override void Entry()
        {
            borderLine.ChangeBorderLineHeight(character,borderLineUnderLength);
        }

        protected override InGameState UpdateGame()
        {
            character.UpdateHeight(Time.deltaTime);
            if (timer.IsTimeOver())
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

            if (character.HeightObservable.Value < borderLine.HeightObservable.Value + borderLineDisplayLength)
            {
                ActiveJumpCard();
                ActiveBoarderLine();
                return InGameState.WaitClick;
            }

            return State;
        }

        private void ActiveJumpCard()
        {
            //TODO: カード設定
        }
        
        private void ActiveBoarderLine()
        {
            borderLineView.SetActive(true);
        }

        protected override void Exit()
        {
            
        }
    }
}