using UnityEngine.Events;
using UnityEngine;
using Core.Loop;

namespace Core.Animation.Sprites
{
    [CreateAssetMenu(fileName = "New Animation", menuName = "Animations/Sprite")]
    public class Animation : FrameAnimation
    {
        [SerializeField] private Sprite[] _sprites;

        public override object Get(double time)
        {
            long frame = (long)(time * FPS);
            //Debug.Log(string.Join(" ", frame, _sprites.Length));
            return _sprites[frame % _sprites.Length];
        }
    }
}