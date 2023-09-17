using System;
using UnityEngine;

namespace Managers.InGameManagerStates
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
        Falling
    }
}