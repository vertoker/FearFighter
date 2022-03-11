using Core.Input.Keys;

namespace Core.Entities.Interfaces.Input
{
    public interface IKeyWorldInteraction
    {
        public void KeyDown(KeyWorldInteraction key);
        public void KeyUp(KeyWorldInteraction key);
    }
}