using UnityEngine;

namespace Core.Animation
{
    public class FrameAnimation : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private int _fps;

        public string Name => _name;
        public int FPS => _fps;

        public virtual object Get(double time)
        {
            return default(object);
        }
    }
}