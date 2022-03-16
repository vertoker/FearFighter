using UnityEngine;

namespace Core.Animation.Transforms
{
    [System.Serializable]
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
            _position = transform.localPosition;
            _rotation = transform.localRotation;
            _localScale = transform.localScale;
        }
        public void CopyTo(Transform transform)
        {
            transform.localPosition = _position;
            transform.localRotation = _rotation;
            transform.localScale = _localScale;
        }
    }
}