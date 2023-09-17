using System;
using Managers;
using UnityEngine;

namespace InGameManagerStates
{
    [Serializable]
    public class InGameStateData
    {
        public InGameState State => state;
        public BaseInGameManager InGameManager=>inGameManager;
        
        [SerializeField] private InGameState state;
        [SerializeField] private BaseInGameManager inGameManager;
    }
    
    public enum InGameState
    {
        Jumping,
        FallStart,
        WaitChooseCard,
        WaitClick,
        OverBoarderLine,
        WaitNextJump,
    }
}