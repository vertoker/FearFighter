using System.Collections;
using System.Collections.Generic;
using Core.Animation.Transforms;
using Core.Input.Keys;
using UnityEngine;

namespace Core.Fighting.Controllers
{
    public class FistsController : FightingController
    {
        [SerializeField] private GameObject _fistLeftObject;
        [SerializeField] private GameObject _fistRightObject;
        private TransformAnimator _fistLeftAnimator, _fistRightAnimator;
        private Transform _fistLeft, fistRight;

        private FistsState _currentState = FistsState.Idle;
        private StateSwitcher _stateSwitcher;

        private void Start()
        {
            _fistLeftAnimator = _fistLeftObject.GetComponent<TransformAnimator>();
            _fistRightAnimator = _fistRightObject.GetComponent<TransformAnimator>();
            _fistLeft = _fistLeftObject.transform;
            fistRight = _fistRightObject.transform;
        }
        /*public override void SetFlip(bool flip)
        {

        }*/


        public override void Move(Vector2 direction)
        {

        }
        public override void Press(KeyWorldInteraction key)
        {

        }
        public override void Press(KeyFighting key)
        {
            switch (key)
            {
                case KeyFighting.Block:
                    break;
                case KeyFighting.FastAttack:
                    SwitchState(FistsState.X);
                    _waiter = StartCoroutine(Task(FistsState.Xend, 1f));
                    break;
                case KeyFighting.StrongAttack:
                    break;
                default:
                    break;
            }
        }
        public override void Press(KeySwitchWeapon key)
        {

        }

        private IEnumerator Task(FistsState nextState, float time)
        {
            yield return new WaitForSeconds(time);
            SwitchState(nextState);
        }
        private void SwitchState(FistsState state)
        {
            _currentState = state;
            _fistLeftAnimator.Switch(_currentState.ToString());
            _fistRightAnimator.Switch(_currentState.ToString());
        }
        private void SwitchState(FistsState state, float time)
        {
            _currentState = state;
            _fistLeftAnimator.Switch(_currentState.ToString());
            _fistRightAnimator.Switch(_currentState.ToString());
        }
    }

    public enum FistsState : byte
    {
        Idle = 0,
        X = 1,
        Xend = 2
    }
}