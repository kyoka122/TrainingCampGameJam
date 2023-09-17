using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UniRx;

namespace Character.View
{
    public class BackGroundView : MonoBehaviour
    {
        [SerializeField] private JumpCharacterHeightModel _character;
        [SerializeField] private GameObject _generateObject;
        [SerializeField] private float _generateY;
        [SerializeField] private Vector3 _generateOffset;

        private float _spanCount;
        private float _bfHeight;

        private async void Awake()
        {
            await UniTask.WaitUntil(() => _character.IsInitialized);

            _spanCount = 0;
            _bfHeight = 0;

            GameObject lastGeneratedObject = _generateObject;

            _character.HeightObservable.Subscribe(height =>
            {
                transform.position = new Vector3(transform.position.x, -height, transform.position.z);

                if(lastGeneratedObject.transform.position.y < _generateY)
                {
                    GameObject obj = Instantiate(_generateObject);
                    obj.transform.parent = transform;
                    obj.transform.position = lastGeneratedObject.transform.position;
                    obj.transform.position += _generateOffset;
                    lastGeneratedObject = obj;
                }
            });
        }
    }
}
