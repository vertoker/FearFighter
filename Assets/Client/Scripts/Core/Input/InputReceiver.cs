using Core.Entities.Controllers;
using Core.Entities.Interfaces;
using Core.Input.Keys;
using UnityEngine;

namespace Core.Input
{
    public class InputReceiver : MonoBehaviour, IInput
    {
        [SerializeField] private Controller _target;

        public void Move(Vector2 direction)
        {
            _target.Move(direction);
        }
        public void Press(KeyWorldInteraction key)
        {
            _target.Press(key);
        }

        public void Press(KeyFighting key)
        {
            _target.Press(key);
        }
        public void Press(KeySwitchWeapon key)
        {
            _target.Press(key);
        }
    }
}