using Managers;

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
            if (OverBorderline())
            {
                return InGameState.OverBoarderLine;
            }
            if ()//Clockしたら
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