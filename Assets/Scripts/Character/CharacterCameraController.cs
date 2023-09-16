using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UniRx;

namespace Character
{
    public class CharacterCameraController : MonoBehaviour
    {
        [SerializeField] private Camera _characterCamera;
        [SerializeField] private JumpCharacter _character;
        [SerializeField] private float _cameraHeightMultiply;

        private bool _isChasing = false;

        private async void Awake()
        {
            await UniTask.WaitUntil(() => _character.IsInitialized);

            _character.transform.parent = _characterCamera.transform;

            _character.State.Subscribe(state =>
            {
                switch (state)
                {
                    case JumpState.Rise:
                        {
                            _isChasing = true;
                            ChaseCharacter().Forget();
                            break;
                        }
                        break;
                    default:
                        {
                            _isChasing = false;
                            break;
                        }
                }
            });
        }

        private async UniTask ChaseCharacter()
        {
            while (_isChasing)
            {
                _characterCamera.transform.position = new Vector3
                    (_characterCamera.transform.position.x,
                    _character.Height.Value * _cameraHeightMultiply,
                    _characterCamera.transform.position.z);

                await UniTask.DelayFrame(1, cancellationToken: this.GetCancellationTokenOnDestroy());
            }
        }
    }
}
