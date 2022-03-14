using UnityEngine;

namespace Core.Animation.Transforms
{
    public struct TransformStruct
    {
        [SerializeField] private Vector3 _position;
        [SerializeField] private Quaternion _rotation;
        [SerializeField] private Vector3 _localScale;

        public Vector3 Position => _position;
        public Quaternion Rotation => _rotation;
        public Vector3 LocalScale => _localScale;

        public void CopyFrom(Transform transform)
        {
            _position = transform.position;
            _rotation = transform.rotation;
            _localScale = transform.localScale;
        }
        public void CopyTo(Transform transform)
        {
            transform.position = _position;
            transform.rotation = _rotation;
            transform.localScale = _localScale;
        }
    }
}