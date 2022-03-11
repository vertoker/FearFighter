using Core.Entities.Controllers;
using Core.Entities.Interfaces;
using Core.Input.Keys;
using UnityEngine;

namespace Core.Input
{
    public class DeviceReceiver : MonoBehaviour, IInput
    {
        private InputReceiver _mainReveiver;
        private MainControls _controls;

        [Header("Debug")]
        [SerializeField] private bool _left;
        [SerializeField] private bool _right;
        [SerializeField] private bool _up;
        [SerializeField] private bool _down;

        private void OnEnable()
        {
            if (_controls == null)
                Init();

            _controls.Enable();
        }
        private void OnDisable()
        {
            _controls.Disable();
        }

        private void Init()
        {
            _mainReveiver = GetComponent<InputReceiver>();
            _controls = new MainControls();

            _controls.Player.MoveLeft.performed += ctx => PressMove(true, KeyMovement.Left);
            _controls.Player.MoveRight.performed += ctx => PressMove(true, KeyMovement.Right);
            _controls.Player.MoveUp.performed += ctx => PressMove(true, KeyMovement.Up);
            _controls.Player.MoveDown.performed += ctx => PressMove(true, KeyMovement.Down);

            _controls.Player.MoveLeft.canceled += ctx => PressMove(false, KeyMovement.Left);
            _controls.Player.MoveRight.canceled += ctx => PressMove(false, KeyMovement.Right);
            _controls.Player.MoveUp.canceled += ctx => PressMove(false, KeyMovement.Up);
            _controls.Player.MoveDown.canceled += ctx => PressMove(false, KeyMovement.Down);

            _controls.Player.Action.performed += _ => Press(KeyWorldInteraction.Action);
            _controls.Player.Jump.performed += _ => Press(KeyWorldInteraction.Jump);
            _controls.Player.Dash.performed += _ => Press(KeyWorldInteraction.Dash);

            _controls.Player.FastAttack.performed += _ => Press(KeyFighting.FastAttack);
            _controls.Player.StrongAttack.performed += _ => Press(KeyFighting.StrongAttack);
            _controls.Player.Block.performed += _ => Press(KeyFighting.Block);

            _controls.Player.Weapon0.performed += _ => Press(KeySwitchWeapon.Fists);
            _controls.Player.Weapon1.performed += _ => Press(KeySwitchWeapon.Sword);
            _controls.Player.Weapon2.performed += _ => Press(KeySwitchWeapon.LongAxe);
            _controls.Player.Weapon3.performed += _ => Press(KeySwitchWeapon.Daggers);
            _controls.Player.Weapon4.performed += _ => Press(KeySwitchWeapon.Club);
            //_controls.Player.Weapon5.performed += _ => Press(KeySwitchWeapon.Brush);
            _controls.Player.Weapon5.performed += _ => Press(KeySwitchWeapon.Crossbow);
        }

        public void PressMove(bool isPressed, KeyMovement movement)
        {
            //Debug.Log(string.Join(" ", isPressed, movement));
            switch (movement)
            {
                case KeyMovement.Left:
                    _left = isPressed;
                    break;
                case KeyMovement.Right:
                    _right = isPressed;
                    break;
                case KeyMovement.Up:
                    _up = isPressed;
                    break;
                case KeyMovement.Down:
                    _down = isPressed;
                    break;
            }

            float horizontal = _left == _right ? 0 : _left == true ? -1 : 1;
            float vertical = _down == _up ? 0 : _down == true ? -1 : 1;
            Move(new Vector2(horizontal, vertical));
        }
        public void Move(Vector2 direction)
        {
            _mainReveiver.Move(direction);
        }
        public void Press(KeyWorldInteraction key)
        {
            _mainReveiver.Press(key);
        }
        public void Press(KeyFighting key)
        {
            _mainReveiver.Press(key);
        }
        public void Press(KeySwitchWeapon key)
        {
            _mainReveiver.Press(key);
        }
    }
}