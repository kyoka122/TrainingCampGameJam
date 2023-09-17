using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

namespace Character.Debugger
{
    public class DebugGameManager : MonoBehaviour
    {
        [SerializeField] private JumpCharacterHeightModel _character;
        [SerializeField] private BorderLine _borderLine;
        [SerializeField] private GameObject _borderLineView;
        [SerializeField] private float _boderLineUnderLength;
        [SerializeField] private float _borderLineDisplayLength;
        [SerializeField] private float _jumpPower;

        private async void Awake()
        {
            await UniTask.WaitUntil(() => _character.IsInitialized);
            await UniTask.WaitUntil(() => _borderLine.IsInitialized);

            //最初一度だけボーダーラインの位置を設定
            _borderLine.ChangeBorderLineHeight(_character, _boderLineUnderLength);
            _borderLineView.SetActive(false);

            _character.Jump(_jumpPower);

            _character.IsFallObservable
                .Where(isfall => isfall)
                .Subscribe(async _ =>
                {
                    _borderLine.ChangeBorderLineHeight(_character, _boderLineUnderLength);

                    await UniTask.WaitUntil(() => _character.HeightObservable.Value < _borderLine.HeightObservable.Value + _borderLineDisplayLength);

                    _borderLineView.SetActive(true);

                    await UniTask.WaitUntil(() => _character.HeightObservable.Value < _borderLine.HeightObservable.Value);

                    _character.Jump(_jumpPower);
                    _borderLineView.SetActive(false);

                }).AddTo(this);
        }

        private void FixedUpdate()
        {
            _character.UpdateHeight(Time.deltaTime);
        }
    }
}
