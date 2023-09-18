using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Zenject;

namespace Character
{
    public class BorderLine : MonoBehaviour
    {
        private ReactiveProperty<float> _heightReactiveProperty;
        private ReadOnlyReactiveProperty<float> _heightReadOnlyReactiveProperty;
        private bool _isInitialized = false;

        public IReadOnlyReactiveProperty<float> HeightObservable => _heightReadOnlyReactiveProperty;
        public bool IsInitialized => _isInitialized;

        private void Awake()
        {
            _heightReactiveProperty = new ReactiveProperty<float>(0).AddTo(this);
            _heightReadOnlyReactiveProperty = _heightReactiveProperty.ToReadOnlyReactiveProperty<float>().AddTo(this);

            _isInitialized = true;
        }

        /// <summary>
        /// 指定秒数後のキャラクターの高さにボーダーラインの高さを変更する
        /// </summary>
        /// <param name="character"> 追従するキャラクター </param>
        /// <param name="atBorderLineTime"> 何秒後の位置にボーダーラインを設定するか </param>
        public void ChangeBorderLineHeight(JumpCharacterHeightModel character, float underLength)
        {
            _heightReactiveProperty.Value = character.HeightObservable.Value - underLength;
        }
    }
}
