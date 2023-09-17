using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UniRx;

namespace Character.View
{
    public class CharacterCameraController : MonoBehaviour
    {
        [SerializeField] private Camera _characterCamera;
        [SerializeField] private JumpCharacterHeightModel _character;
        [SerializeField] private List<GameObject> _cameraChaseObject;
        [SerializeField] private float _cameraHeightMultiply;
        [SerializeField] private bool _isIgnoreChaseOnFall;

        private void Awake()
        {
            foreach(GameObject obj in _cameraChaseObject)
            {
                obj.transform.parent = _characterCamera.transform;
            }
        }

        private void Update()
        {
            var cameraPosition = new Vector3
                (_characterCamera.transform.position.x,
                _character.HeightObservable.Value * _cameraHeightMultiply,
                _characterCamera.transform.position.z);

            if (_isIgnoreChaseOnFall)
            {
                if (!(_characterCamera.transform.position.y < cameraPosition.y)) return;
            }
            
            _characterCamera.transform.position = cameraPosition;
        }
    }
}
