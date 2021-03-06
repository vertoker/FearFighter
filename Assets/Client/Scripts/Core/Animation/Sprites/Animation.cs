using UnityEngine.Events;
using UnityEngine;
using Core.Loop;
using Common;

namespace Core.Animation.Sprites
{
    [CreateAssetMenu(fileName = "New Animation", menuName = "Animations/Sprite")]
    public class Animation : FrameAnimation
    {
        [SerializeField] private Sprite[] _sprites;

        public Sprite Get(double time)
        {
            long frame = (long)(time * FPS);
            //Debug.Log(string.Join(" ", frame, _sprites.Length));
            return Loop ? _sprites[frame % _sprites.Length] : _sprites[Functions.Clamp(frame, 0, _sprites.Length - 1)];
        }
    }
}