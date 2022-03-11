using Core.Input.Keys;
using UnityEngine;

namespace Core.Entities.Interfaces
{
    interface IInput
    {
        public void Move(Vector2 direction);
        public void Press(KeyWorldInteraction key);
        public void Press(KeyFighting key);
        public void Press(KeySwitchWeapon key);
    }
}
