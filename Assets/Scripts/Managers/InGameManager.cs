using System.Collections.Generic;
using InGameManagerStates;
using UnityEngine;

namespace Managers
{
    public class InGameManager:MonoBehaviour
    {
        [SerializeField] private JumpingInGame firstInGameState;
        
        private void Start()
        {
            firstInGameState.Run();
        }
        

    }
}