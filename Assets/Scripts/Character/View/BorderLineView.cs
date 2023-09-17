using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace Character.View
{
    public class BorderLineView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private AnimationCurve _curve;
        [SerializeField] private float _excutionTime;

        [SerializeField] private JumpCharacterHeightModel _character;
        [SerializeField] private BorderLine _borderLine;
        [SerializeField] private Color _color;

        private bool _isExcution = false;
        private float _timeCounter = 0;
        private Color _originColor;

        private void Awake()
        {
            _originColor = _spriteRenderer.color;

            this.ObserveEveryValueChanged(isActive => gameObject.activeSelf).Subscribe(isActive =>
            {
                if (isActive)
                {
                    _isExcution = true;
                    _spriteRenderer.color = new Color(_spriteRenderer.color.r, _spriteRenderer.color.g, _spriteRenderer.color.b, 0);
                }
            }).AddTo(this);
        }

        private void Update()
        {
            if(_borderLine.HeightObservable.Value < _character.HeightObservable.Value)
            {
                _spriteRenderer.color = _color;
            }
            else
            {
                _spriteRenderer.color = _originColor;
            }

            if(_isExcution)
            {
                _timeCounter += Time.deltaTime;

                _spriteRenderer.color = new Color(_spriteRenderer.color.r, _spriteRenderer.color.g, _spriteRenderer.color.b, _spriteRenderer.color.a + _curve.Evaluate(_timeCounter/_excutionTime));

                if(_spriteRenderer.color.a >= 1.0f)
                {
                    _spriteRenderer.color = new Color(_spriteRenderer.color.r, _spriteRenderer.color.g, _spriteRenderer.color.b, 1.0f);
                    _isExcution = false;
                    _timeCounter = 0;
                }
            }
        }
    }
}
