using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Fighting
{
    public class StateSwitcher
    {
        private StateHolder[] _tasks;
        private MonoBehaviour _mono;
        private StateDelegate _stateDelegate;

        private Coroutine _current;
        private int _counter;

        public StateSwitcher(MonoBehaviour mono, StateDelegate stateDelegate)
        {
            _mono = mono;
            _stateDelegate = stateDelegate;
        }

        public void Start(StateHolder[] tasks)
        {
            Stop();
            _counter = 0;
            _tasks = tasks;
            _mono.StartCoroutine(Task());
        }
        public void Stop()
        {
            if (_current != null)
                _mono.StopCoroutine(_current);
        }

        private IEnumerator Task()
        {
            yield return new WaitForSeconds(_tasks[_counter].time);
            _stateDelegate.Invoke(_tasks[_counter].state);
            _counter++;

            if (_tasks.Length > _counter)
            {
                _mono.StartCoroutine(Task());
            }
        }
    }
    public delegate void StateDelegate(byte state);
}