using Core.Entities.AnimationController;
using Core.Entities.Controllers;
using Core.Input.Keys;

using System.Collections;
using UnityEngine;

namespace Core.Entities.Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : InputBlock
    {
        [Header("Parameters")]
        [SerializeField] private float _powerMove = 1f;
        [SerializeField] private float _powerDash = 1f;
        [SerializeField] private float _timeDash = 0.3f;
        [SerializeField] private float _cooldownDash = 0.3f;

        [SerializeField] private Vector2 _direction;
        private bool _isDash = false;
        private bool _canDash = true;
        private Coroutine _dashTimer;
        private Coroutine _dashCooldown;
        
        private Rigidbody2D _rb;
        private PlayerAnimationController _animator;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _animator = GetComponent<PlayerAnimationController>();
        }

        public override void Move(Vector2 direction)
        {
            if (!_isDash)
            {
                _direction = direction;
                _animator.Move(direction);
            }
            UpdateMovement();
        }
        public override void Press(KeyWorldInteraction key)
        {
            switch (key)
            {
                case KeyWorldInteraction.Action:
                    Debug.Log("Action");
                    break;
                case KeyWorldInteraction.Dash:
                    Dash();
                    break;
            }
        }

        private void Dash()
        {
            if (_isDash || !_canDash)
                return;
            _isDash = true;
            _canDash = false;
            UpdateMovement();

            _animator.DashStart();
            if (_dashTimer != null)
                StopCoroutine(_dashTimer);
            _dashTimer = StartCoroutine(DashTimer());
            if (_dashCooldown != null)
                StopCoroutine(_dashCooldown);
            _dashCooldown = StartCoroutine(DashCooldown());
        }
        private IEnumerator DashTimer()
        {
            yield return new WaitForSeconds(_timeDash);
            _animator.DashEnd();
            _isDash = false;
            UpdateMovement();
        }
        private IEnumerator DashCooldown()
        {
            yield return new WaitForSeconds(_cooldownDash);
            _canDash = true;
            UpdateMovement();
        }

        private void UpdateMovement()
        {
            if (_isDash)
                _rb.velocity = _direction * _powerDash;
            else
                _rb.velocity = _direction * _powerMove;
        }

        private void Update()//������� ������� ����������
        {
            UpdateMovement();
        }
    }
}
