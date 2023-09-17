using System.Collections.Generic;
using System.Linq;
using InGameManagerStates;
using UnityEngine;

namespace Managers
{
    public abstract class BaseInGameManager : MonoBehaviour
    {
        protected abstract InGameState State { get; }
        
        [SerializeField] private List<InGameStateData> stateData;
        
        private BaseInGameManager _currentInGameManager;

        private void Start()
        {
            _currentInGameManager = stateData.First().InGameManager;
            _currentInGameManager.Entry();
        }

        private void Update()
        {
            var newState = _currentInGameManager.UpdateGame();
            if (newState!=_currentInGameManager.State)
            {
                _currentInGameManager.Exit();
                _currentInGameManager = stateData.Find(data => data.State==newState).InGameManager;
                _currentInGameManager.Entry();
            }
        }

        protected abstract void Entry();

        protected abstract InGameState UpdateGame();

        protected abstract void Exit();
        

        #region Actions

        protected void Jump()
        {
            
        }

        protected void ActiveJumpCard()
        {
            
        }

        protected bool OverBorderline()
        {
            
        }

        #endregion

    }
}