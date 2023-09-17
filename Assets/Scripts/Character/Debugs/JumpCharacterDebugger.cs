using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using TMPro;

namespace Character.Debugger
{
    public class JumpCharacterDebugger : MonoBehaviour
    {
        [SerializeField] private JumpCharacter _character;
        [SerializeField] private float _jumpPower;
        [SerializeField] private TMP_Text _heightText;
        [SerializeField] private TMP_Text _stateText;

        private async void Awake()
        {
            await UniTask.WaitUntil(() => _character.IsInitialized);

            _character.Height.Subscribe(value => _heightText.text = "" + value.ToString());

            _character.State.Subscribe(value => _stateText.text = value.ToString());

            this.UpdateAsObservable().Subscribe(_ =>
            {
                if (Input.GetKey(KeyCode.Space)) _character.Jump(_jumpPower);
            }).AddTo(this);
        }
    }
}
