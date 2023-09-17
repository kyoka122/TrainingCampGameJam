using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UniRx;

namespace Character.Animation
{
    public class CharacterAnimationController : MonoBehaviour
    {
        [SerializeField] private JumpCharacterHeightModel _character;
        [SerializeField] private Animator _animator;

        private async void Awake()
        {
            await UniTask.WaitUntil(() => _character.IsInitialized);

            _character.IsFallObservable.Subscribe(isFall =>
            {
                _animator.SetBool("Fall", isFall);
            }).AddTo(this);
        }
    }
}
