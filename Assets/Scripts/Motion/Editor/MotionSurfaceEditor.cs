using Motion.Debug;
using Motion.Unity;
using UnityEditor;
using UnityEngine;

namespace Motion.Editor
{
    [CustomEditor(typeof(MotionSurfaceTest))]
    public class MotionSurfaceEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            MotionSurfaceTest behaviour = (MotionSurfaceTest)target;
            var surface = behaviour.GetSurface();
            if (surface)
            {
                if (GUILayout.Button("Generate", GUILayout.Height(20)))
                {
                    surface.GenerateMesh();
                }
            }
        }
    }
}
