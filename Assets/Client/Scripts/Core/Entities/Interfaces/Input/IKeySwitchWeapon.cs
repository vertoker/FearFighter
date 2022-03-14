using Core.Input.Keys;

namespace Core.Entities.Interfaces.Input
{
    public interface IKeySwitchWeapon
    {
        public void KeyDown(KeySwitchWeapon key);
        public void KeyUp(KeySwitchWeapon key);
    }
}