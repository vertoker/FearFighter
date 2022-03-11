using Core.Entities.Interfaces;
using Core.Input.Keys;
using UnityEngine;

namespace Core.Entities.Controllers
{
    public class InputBlock : MonoBehaviour, IInput
    {
        public virtual void Move(Vector2 direction)
        {

        }
        public virtual void Press(KeyWorldInteraction key)
        {

        }
        public virtual void Press(KeyFighting key)
        {

        }
        public virtual void Press(KeySwitchWeapon key)
        {

        }
    }
}