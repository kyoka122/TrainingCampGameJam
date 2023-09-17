using System;
using Managers;
using UnityEngine;

namespace InGameManagerStates
{
    [Serializable]
    public class InGameStateData
    {
        public InGameState State => state;
        public BaseInGameState InGameState=>inGameState;
        
        [SerializeField] private InGameState state;
        [SerializeField] private BaseInGameState inGameState;
    }
    
    public enum InGameState
    {
        Jumping,
        FallStart,
        WaitClick,
        PlayUI,
        WaitNextJump,
    }
}