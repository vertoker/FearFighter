using UnityEngine;

namespace Core.Animation
{
    public class FrameAnimation : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private int _fps;
        [SerializeField] private bool _loop;

        public string Name => _name;
        public int FPS 
        {
            get { return _fps; }
            set { _fps = value; }
        }
        public bool Loop 
        {
            get { return _loop; }
            set { _loop = value; }
        }

        public virtual object Get(double time)
        {
            return default(object);
        }
    }
}