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

        private bool _isExcution = false;
        private float _timeCounter = 0;

        private void Awake()
        {
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
            if(_isExcution)
            {
                _timeCounter += Time.deltaTime;

                _spriteRenderer.color = new Color(_spriteRenderer.color.r, _spriteRenderer.color.g, _spriteRenderer.color.b, _spriteRenderer.color.a + _curve.Evaluate(_timeCounter/_excutionTime));

                if(_spriteRenderer.color.a >= 1.0f)
                {
                    _spriteRenderer.color = new Color(_spriteRenderer.color.r, _spriteRenderer.color.g, _spriteRenderer.color.b, 1.0f);
                    _isExcution = false;
                }
            }
        }
    }
}
