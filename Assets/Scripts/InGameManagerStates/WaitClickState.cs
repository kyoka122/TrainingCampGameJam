using Managers;
using UnityEngine;

namespace InGameManagerStates
{
    public class WaitClickState:BaseInGameManager
    {
        protected override InGameState State => InGameState.WaitClick;
        
        protected override void Entry()
        {
            
        }

        protected override InGameState UpdateGame()
        {
            timer.UpdateTimer();
            if (timer.IsTimeOver())
            {
                Finish();
            }
            character.UpdateHeight(Time.deltaTime);
            
            if (OverBorderline())
            {
                GameOver();
                return InGameState.PlayUI;
            }
            if (Input.GetMouseButtonDown(0))//Clockしたら
            {
                //カード情報を取得
                string cardType = GetCardType();
                CreateJumpObject(cardType);
                return InGameState.WaitNextJump;
            }
            
            return State;
        }

        private void CreateJumpObject(string cardType)
        {
            
        }

        private string GetCardType()//TODO: Enumができたらそちらに移行。
        {
            
        }

        protected override void Exit()
        {
            
        }
    }
}