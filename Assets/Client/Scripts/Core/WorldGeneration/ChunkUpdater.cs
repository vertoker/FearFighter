using System.Collections;
using UnityEngine;

namespace Core.WorldGeneration
{
    public class ChunkUpdater : MonoBehaviour//Требуется заменить на event по загрузке entities локации
    {
        [SerializeField] private float _time = 0.5f;
        private TargetLoader _loader;
        private Coroutine _main;

        private void Awake()
        {
            _loader = GetComponent<TargetLoader>();
        }
        public void Start()
        {
            _main = StartCoroutine(Timer());
        }
        public void Stop()
        {
            StopCoroutine(_main);
        }

        private IEnumerator Timer()
        {
            while (true)
            {
                yield return new WaitForSeconds(_time);
                _loader.UpdateChunks();
            }
        }
    }
}
