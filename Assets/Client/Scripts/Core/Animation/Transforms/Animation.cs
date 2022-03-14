using UnityEngine.Events;
using UnityEngine;
using Core.Loop;

namespace Core.Animation.Transforms
{
    [CreateAssetMenu(fileName = "New Animation", menuName = "Animations/SpTransformrite")]
    public class Animation : FrameAnimation
    {
        [SerializeField] private TransformStruct[] _points;

        public override object Get(double time)
        {
            long frame = (long)(time * FPS);
            //Debug.Log(string.Join(" ", frame, _points.Length));
            return _points[frame % _points.Length];
        }
    }
}