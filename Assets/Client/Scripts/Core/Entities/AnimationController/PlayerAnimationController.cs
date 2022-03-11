using Core.Entities.Controllers;
using Core.Input.Keys;
using Core.Animation;
using UnityEngine;

namespace Core.Entities.AnimationController
{
    public class PlayerAnimationController : MonoBehaviour
    {
        [SerializeField] private SpriteAnimator _animator;
        [SerializeField] private SpriteRenderer _renderer;
        private Vector2 _lastDirection;

        public void Move(Vector2 direction)
        {
            _lastDirection = direction;
            if (_lastDirection.x != 0)
            {
                SetFlip(_lastDirection.x < 0);
                SetState(PlayerState.Move);
            }
            else
            {
                SetState(PlayerState.Idle);
            }
        }
        public void JumpStart()
        {
            SetState(PlayerState.Jump);
        }
        public void JumpEnd()
        {
            Move(_lastDirection);
        }
        public void DashStart()
        {
            SetState(PlayerState.Dash);
        }
        public void DashEnd()
        {
            Move(_lastDirection);
        }

        //Fighting
        public void Press(KeyFighting key)
        {

        }
        public void Press(KeySwitchWeapon key)
        {

        }

        public void SetState(PlayerState state)
        {
            _animator.Switch(state.ToString());
        }
        public void SetFlip(bool isLeft)
        {
            _renderer.flipX = isLeft;
        }
    }

    public enum PlayerState : byte
    {
        Idle = 0,
        Move = 1,
        Falling = 2,
        FallingMove = 3,
        Jump = 4,
        JumpMove = 5,
        Dash = 6
    }
}