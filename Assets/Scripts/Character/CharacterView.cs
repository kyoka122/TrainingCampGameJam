using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UniRx;

namespace Character
{
    public class CharacterView : MonoBehaviour
    {
        [SerializeField] private JumpCharacterHeightModel _character;
        [SerializeField] private BorderLine _borderLine;
        [SerializeField] private GameObject _borderLineView;
        [SerializeField] private float _maxLocalHeight;

        private async void Awake()
        {
            await UniTask.WaitUntil(() => _character.IsInitialized);

            _character.HeightObservable.Subscribe(height =>
            {
                var characterLocalHeight = (height - _borderLine.HeightObservable.Value);
                characterLocalHeight += _borderLineView.transform.localPosition.y;

                if (characterLocalHeight < _maxLocalHeight) 
                {
                    transform.localPosition = new Vector3(transform.localPosition.x, characterLocalHeight, transform.localPosition.z);
                }
                else
                {
                    transform.localPosition = new Vector3(transform.localPosition.x, _maxLocalHeight, transform.localPosition.z);
                }
            }).AddTo(this);
        }
    }
}
