using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UniRx;
using TMPro;

namespace Character.View
{
    public class CharacterHeightView : MonoBehaviour
    {
        [SerializeField] private JumpCharacterHeightModel _character;
        [SerializeField] private TMP_Text _text;

        private async void Awake()
        {
            await UniTask.WaitUntil(() => _character.IsInitialized);

            _character.HeightObservable.Subscribe(height =>
            {
                var heightInteger = (int)(height * 100);
                _text.text = ((float)heightInteger / 100f).ToString();
            }).AddTo(this);
        }
    }
}
