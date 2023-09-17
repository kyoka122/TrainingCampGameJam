using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UniRx;

namespace Character
{
    public class CharacterCameraController : MonoBehaviour
    {
        [SerializeField] private Camera _characterCamera;
        [SerializeField] private JumpCharacterHeightModel _character;
        [SerializeField] private GameObject _characterView;
        [SerializeField] private GameObject _borderLineView;
        [SerializeField] private float _cameraHeightMultiply;

        private void Awake()
        {
            _characterView.transform.parent = _characterCamera.transform;
            _borderLineView.transform.parent = _characterCamera.transform;
        }

        private void Update()
        {
            var cameraPosition = new Vector3
                (_characterCamera.transform.position.x,
                _character.HeightObservable.Value * _cameraHeightMultiply,
                _characterCamera.transform.position.z);

            if (_characterCamera.transform.position.y < cameraPosition.y) _characterCamera.transform.position = cameraPosition;
        }
    }
}
