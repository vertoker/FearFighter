using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Animation.Transforms
{
    public class TransformAnimator : MonoBehaviour
    {
        [SerializeField] private List<Animation> _animations = new List<Animation>();
        [SerializeField] private Animation _current;
        [SerializeField] private Transform _transform;

        private double startTime, currentTime;

        private void OnEnable()
        {
            AnimationExecutor.UpdateTimer += UpdateTransform;
        }
        private void OnDisable()
        {
            AnimationExecutor.UpdateTimer -= UpdateTransform;
        }

        public void Switch(string name)
        {
            //Debug.Log(string.Format("Object {0} switch animation to {1}", gameObject.name, name));
            Animation anim = _animations.Find((Animation anim) => anim.Name == name);

            if (anim == null)
                return;

            _current = anim;
            startTime = currentTime;
            UpdateTransform(currentTime);
        }

        private void UpdateTransform(double time)
        {
            currentTime = time;
            ((TransformStruct)_current.Get(currentTime - startTime)).CopyTo(_transform);
        }
}
}