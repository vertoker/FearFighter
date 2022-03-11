using Core.Input.Keys;

namespace Core.Entities.Interfaces.Input
{
    public interface IKeyFighting
    {
        public void KeyDown(KeyFighting key);
        public void KeyUp(KeyFighting key);
    }
}