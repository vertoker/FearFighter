using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using Core.Loop;

namespace Core.World
{
    class MapBoundsLoop : MonoBehaviour
    {
        [SerializeField] private float _timeUpdate = 0.5f;
        private Coroutine _main;

        private readonly static UnityEvent _updateEvent = new UnityEvent();

        public static event UnityAction UpdateTimer
        {
            add => _updateEvent.AddListener(value);
            remove => _updateEvent.RemoveListener(value);
        }

        private void Start()
        {
            _updateEvent.Invoke();
            _main = StartCoroutine(Timer());
        }

        private IEnumerator Timer()
        {
            while (true)
            {
                yield return new WaitForSeconds(_timeUpdate);
                _updateEvent.Invoke();
            }
        }
    }
}
