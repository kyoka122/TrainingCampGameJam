using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UniRx;

namespace Character
{
    public class JumpCharacter : MonoBehaviour
    {
        [SerializeField] private BoxCollider _boxCollider;
        [SerializeField] private float _maxHeight;
        [SerializeField] private float _stopTimeMultiply;

        private IJumpLogic _jumpLogic;

        private ReactiveProperty<float> _height;
        private ReactiveProperty<JumpState> _state;
        private float _speed;
        private float _jumpingTime;
        private bool _isInitialized = false;

        public float Top => _boxCollider.size.y / 2 + transform.position.y;
        public float Buttom => _boxCollider.size.y / 2 + transform.position.y;
        public IReadOnlyReactiveProperty<float> Height => _height;
        public IReadOnlyReactiveProperty<JumpState> State => _state;
        public bool IsInitialized => _isInitialized;

        private void Awake()
        {
            _height = new ReactiveProperty<float>(0);
            _state = new ReactiveProperty<JumpState>(JumpState.Fall);

            _isInitialized = true;
        }

        private float timeCounter = 0;
        private void Update()
        {
            _height.Value += _speed * Time.deltaTime;

            switch (_state.Value)
            {
                case JumpState.Stop:
                    {
                        timeCounter += Time.deltaTime;
                        _height.Value += _speed * Time.deltaTime;

                        if (timeCounter < _speed * _stopTimeMultiply) break;

                        _speed = -_speed;
                        _state.Value = JumpState.Fall;
                    }
                    break;

                case JumpState.Rise:
                    {
                        transform.localPosition += new Vector3(0, _speed * Time.deltaTime, 0);
                        if (transform.localPosition.y > _maxHeight)
                        {
                            transform.localPosition = new Vector3(transform.localPosition.x, _maxHeight, transform.localPosition.z);
                            _state.Value = JumpState.Stop;
                            timeCounter = 0;
                        }
                        else if (_speed < 0) _state.Value = JumpState.Fall;
                    }
                    break;

                case JumpState.Fall:
                    {
                        transform.localPosition += new Vector3(0, _speed * Time.deltaTime, 0);
                        if (_speed > 0) _state.Value = JumpState.Rise;
                    }
                    break;
            }
        }

        /// <summary>
        /// ジャンプを行う
        /// </summary>
        public void Jump(float power)
        {
            _speed = power;
        }

        /// <summary>
        /// ジャンプ頂点中の処理
        /// </summary>
        private async UniTask ProcessJumpStop()
        {
            float timeCounter = 0;
            while(timeCounter < _speed * _stopTimeMultiply)
            {
                await UniTask.DelayFrame(1, cancellationToken: this.GetCancellationTokenOnDestroy());

                timeCounter += Time.deltaTime;
                _height.Value += _speed * Time.deltaTime;
            }

            _speed = -_speed;
        }
    }
}
