using System.Linq;
using Managers;
using UnityEngine;

namespace InGameManagerStates
{
    public class WaitNextJumpInGame:BaseInGameState
    {
        protected override InGameState State => InGameState.WaitNextJump;
        protected override void Entry()
        {
            
        }

        protected override InGameState UpdateGame()
        {
            Timer.UpdateTimer();
            if (Timer.IsTimeOver())
            {
                Finish();
                return InGameState.PlayUI;
            }
            
            Character.UpdateHeight(Time.deltaTime);
            
            
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
            float height=CardData.jumpObjectLists.First(data => data.objectName == GetClick.chosenJumpObjectType).jumpHeight;
            Character.Jump(height);//TODO: 初速を変える？ GetClick.chosenJumpObjectTypeから次のジャンプオブジェクトを取得できる。
        }
    }
}