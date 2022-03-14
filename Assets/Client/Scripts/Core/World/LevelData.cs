using UnityEngine.SceneManagement;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Core.World
{
    [CreateAssetMenu(fileName = "NewLevelData", menuName = "Data/Level Data")]
    public class LevelData : ScriptableObject
    {
        [Header("Runtime")]
        [SerializeField] private string _sceneName;
        [SerializeField] private Rect _borders;
        [SerializeField] private float _loadDistance = 10;

#if UNITY_EDITOR
        [Header("Debug")]
        [SerializeField] private Vector2 _center;
        [SerializeField] private Vector2 _size;
        [SerializeField] private SceneAsset _scene;

        public void CalculateBounds()
        {
            Vector2 position = _center - _size / 2;
            _borders = new Rect(position, _size);
        }
        public void FillSceneInformation()
        {
            _sceneName = _scene.name;
        }
#endif

        public string Name => _sceneName;

        public bool InBounds(Vector2 position)
        {
            float x = Mathf.Clamp(position.x, _borders.xMin, _borders.xMax);
            float y = Mathf.Clamp(position.y, _borders.yMin, _borders.yMax);
            //Debug.Log(string.Join(" ", x, y, position, Vector2.Distance(position, new Vector2(x, y)), _loadDistance));
            return Vector2.Distance(position, new Vector2(x, y)) < _loadDistance;
        }

#if UNITY_EDITOR
        [CustomEditor(typeof(LevelData))]
        class DebugData : Editor
        {
            public override void OnInspectorGUI()
            {
                DrawDefaultInspector();
                LevelData data = (LevelData)target;

                if (GUILayout.Button("Update"))
                {
                    data.CalculateBounds();
                    data.FillSceneInformation();
                }
            }
        }
#endif
    }
}