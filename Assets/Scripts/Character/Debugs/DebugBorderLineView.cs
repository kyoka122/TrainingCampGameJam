using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UniRx;

namespace Character.Debugger
{
    public class DebugBorderLineView : MonoBehaviour
    {
        [SerializeField] private BorderLine _borderLine;

        private async void Awake()
        {
            await UniTask.WaitUntil(() => _borderLine.IsInitialized);

            _borderLine.HeightObservable.Subscribe(height =>
            {
                _borderLine.transform.position = new Vector2(transform.position.x, height);
            });
        }
    }
}
