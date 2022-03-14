using Core.Input.Keys;

namespace Core.Entities.Interfaces.Input
{
    public interface IKeyMovement
    {
        public void KeyDown(KeyMovement key);
        public void KeyUp(KeyMovement key);
    }
}