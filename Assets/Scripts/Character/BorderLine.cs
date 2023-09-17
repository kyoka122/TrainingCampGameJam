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
        /// �w��b����̃L�����N�^�[�̍����Ƀ{�[�_�[���C���̍�����ύX����
        /// </summary>
        /// <param name="character"> �Ǐ]����L�����N�^�[ </param>
        /// <param name="atBorderLineTime"> ���b��̈ʒu�Ƀ{�[�_�[���C����ݒ肷�邩 </param>
        public void ChangeBorderLineHeight(JumpCharacterHeightModel character, float underLength)
        {
            _heightReactiveProperty.Value = character.HeightObservable.Value - underLength;
        }
    }
}
