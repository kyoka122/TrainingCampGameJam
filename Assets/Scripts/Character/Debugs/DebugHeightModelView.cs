using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UniRx;

namespace Character.Debugger
{
    public class DebugHeightModelView : MonoBehaviour
    {
        [SerializeField] private JumpCharacterHeightModel _characterModel;

        private async void Awake()
        {
            await UniTask.WaitUntil(() => _characterModel.IsInitialized);

            _characterModel.HeightObservable.Subscribe(height => 
            {
                _characterModel.transform.position = new Vector3(transform.position.x, height, transform.position.z);
            });
        }
    }
}
