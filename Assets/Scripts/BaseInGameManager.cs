using System;
using UnityEngine;

namespace Managers
{
    public abstract class InGameManager : MonoBehaviour
    {
        private InGameManager
        private enum InGameState
        {
            Jumping,
            Falling
        }
        
        private void Update()
        {
            

        }

        #region Actions

        private void Jump()
        {

        }

        private void ActiveJumpCard()
        {

        }

        #endregion

        #region Updates

        private void UpdateWhileJump()
        {
            
        }

        private void UpdateWhileActiveCard()
        {
            if (click)
            {
                ActiveJumpCard();
            }
        }

        #endregion


    }
}