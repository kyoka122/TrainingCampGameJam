using Managers;
using UnityEngine;

namespace InGameManagerStates
{
    public class WaitClickInGame:BaseInGameState
    {
        protected override InGameState State => InGameState.WaitClick;
        
        protected override void Entry()
        {
            
        }

        protected override InGameState UpdateGame()
        {
            Timer.UpdateTimer();
            if (Timer.IsTimeOver())
            {
                Finish();
            }
            Character.UpdateHeight(Time.deltaTime);
            
            if (OverBorderline())
            {
                GameOver();
                return InGameState.PlayUI;
            }
            
            GetClick.UpdateClickedJumpObject();
            Debug.Log($"type:{GetClick.chosenJumpObjectType}");

            if (GetClick.chosenJumpObjectType == null)
            {
                return State;
            }
            if (GetClick.chosenJumpObjectType == JumpObjectType.Dummy)
            {
                //TODO: 箱を壊す処理（アニメーション）
                GameOver();
            }
            
            CreateJumpObject(GetClick.chosenJumpObjectType);
            return InGameState.WaitNextJump;
        }

        private void CreateJumpObject(JumpObjectType? jumpObjectType)
        {
            JumpObjectBase.sprite = CardData.jumpObjectLists.Find(data => data.objectName == jumpObjectType)
                .jumpObjectSprite;
            JumpObjectBase.enabled = true;
        }

        protected override void Exit()
        {
            
        }
    }
}