using UnityEngine.Events;
using UnityEngine;
using Core.Loop;
using Common;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Core.Animation.Transforms
{
    [CreateAssetMenu(fileName = "New Animation", menuName = "Animations/Transform")]
    public class Animation : FrameAnimation
    {
        [SerializeField] private TransformStruct[] _points;
#if UNITY_EDITOR
        public TransformStruct[] Points { get { return _points; } set { _points = value; }}
        [Header("Debug")]
        public int idSelect = 0;
#endif

        public override object Get(double time)
        {
            long frame = (long)(time * FPS);
            //Debug.Log(string.Join(" ", frame, _points.Length));
            return Loop ? _points[frame % _points.Length] : _points[Functions.Clamp(frame, 0, _points.Length - 1)];
        }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(Animation))]
    class DebugAnimation : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            Animation data = (Animation)target;

            if (GUILayout.Button("Add Point"))
            {
                TransformStruct[] newFrames = new TransformStruct[data.Points.Length + 1];
                for (int i = 0; i < data.Points.Length; i++)
                {
                    newFrames[i] = data.Points[i];
                }
                newFrames[data.Points.Length] = new TransformStruct();
                newFrames[data.Points.Length].CopyFrom(Selection.activeTransform);
                data.Points = newFrames;
            }
            if (GUILayout.Button("Paste Point"))
            {
                data.Points[data.idSelect].CopyTo(Selection.activeTransform);
            }
        }
    }
#endif
}