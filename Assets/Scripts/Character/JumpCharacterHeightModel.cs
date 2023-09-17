using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Zenject;

namespace Character
{
    public class JumpCharacterHeightModel : MonoBehaviour
    {
        [Inject] private IJumpLogic _jumpLogic;

        private ReactiveProperty<float> _heightReactiveProperty;
        private ReadOnlyReactiveProperty<float> _heightReadOnlyReactiveProperty;
        private ReactiveProperty<bool> _isFallReactiveProperty;
        private ReadOnlyReactiveProperty<bool> _isFallReadOnlyReactiveProperty;

        private bool _isInitialized = false;

        public IReadOnlyReactiveProperty<float> HeightObservable => _heightReadOnlyReactiveProperty;
        public IReadOnlyReactiveProperty<bool> IsFallObservable => _isFallReadOnlyReactiveProperty;
        public bool IsInitialized => _isInitialized;

        private void Awake()
        {
            _heightReactiveProperty = new ReactiveProperty<float>(0).AddTo(this);
            _heightReadOnlyReactiveProperty = _heightReactiveProperty.ToReadOnlyReactiveProperty<float>().AddTo(this);

            _isFallReactiveProperty = new ReactiveProperty<bool>(false).AddTo(this);
            _isFallReadOnlyReactiveProperty = _isFallReactiveProperty.ToReadOnlyReactiveProperty<bool>().AddTo(this);

            _isInitialized = true;
        }

        /// <summary>
        /// 更新ロジック
        /// </summary>
        public void UpdateHeight(float deltaTime)
        {
            var deltHeight = _jumpLogic.GetDeltaHeight(Time.deltaTime);
            _heightReactiveProperty.Value += deltHeight;

            if (deltHeight < 0) _isFallReactiveProperty.Value = true;
            else _isFallReactiveProperty.Value = false;
        }

        /// <summary>
        /// ジャンプのロジックによってスコアの推移を行う
        /// </summary>
        public void Jump(float power)
        {
            _jumpLogic.Jump(power);
        }
    }
}

