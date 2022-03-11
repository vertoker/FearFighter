using Core.Loop;

using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Core.World
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private LevelData[] _data;
        [SerializeField] private List<string> _activeSceneNames = new List<string>();

        private void OnEnable()
        {
            TimerLoop.UpdateTimer += ComputeLevelsLoad;
        }
        private void OnDisable()
        {
            TimerLoop.UpdateTimer -= ComputeLevelsLoad;
        }
        private void Awake()
        {
            _activeSceneNames = new List<string>();
        }

        private void ComputeLevelsLoad(double time)// Optimize
        {
            Vector2 targetPosition = target.position;
            foreach (var level in _data)
            {
                if (level.InBounds(targetPosition))
                {
                    LoadSubScene(level.Name);
                }
                else
                {
                    UnloadSubScene(level.Name);
                }
                //Debug.Log(string.Join(" ", level.InBounds(target.position), level.Name));
            }
        }
        private void LoadSubScene(string name)
        {
            if (!_activeSceneNames.Contains(name))
            {
                SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);
                _activeSceneNames.Add(name);
            }
        }
        private void UnloadSubScene(string name)
        {
            if (_activeSceneNames.Remove(name))
                SceneManager.UnloadSceneAsync(name);
        }

#if UNITY_EDITOR
        public void LoadAll()
        {
            int counter = 0;
            foreach (var scene in _data)
            {
                try
                {
                    //EditorSceneManager.OpenScene();
                    LoadSubScene(scene.Name);
                    counter++;
                }
                catch (System.Exception)
                {
                    throw;
                }
            }
            Debug.Log(string.Format("Load {0} from {1} scenes", counter, _data.Length));
        }
        public void UnloadAll()
        {
            int counter = 0, length = _activeSceneNames.Count;
            foreach (var scene in _data)
            {
                try
                {
                    UnloadSubScene(scene.Name); 
                    counter++;
                }
                catch (System.Exception)
                {
                    throw;
                }
            }
            Debug.Log(string.Format("Unload {0} scenes from {1} active scenes", counter, length));
        }
#endif
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(SceneLoader))]
    class DebugLoader : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            SceneLoader data = (SceneLoader)target;

            if (GUILayout.Button("Load All"))
            {
                data.LoadAll();
            }
            if (GUILayout.Button("Unload All"))
            {
                data.UnloadAll();
            }
        }
    }
#endif
}