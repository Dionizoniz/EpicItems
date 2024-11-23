using EpicItems.Core.Engine;
using UnityEngine;

namespace EpicItems.Core.Utilities
{
    public class Rotate : ExtendedMonoBehaviour
    {
        [SerializeField]
        private Vector3 _axis = Vector3.forward;
        [SerializeField]
        private float _speed = 100f;

        private void Update()
        {
            float offset = _speed * Time.deltaTime;
            _transform.Rotate(_axis, offset);
        }
    }
}
