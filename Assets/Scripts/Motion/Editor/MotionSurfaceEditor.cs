using Motion.Debug;
using Motion.UnityBehaviour;
using UnityEditor;
using UnityEngine;

namespace Motion.Editor
{
    [CustomEditor(typeof(SurfaceGizmosTest))]
    public class MotionSurfaceEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            SurfaceGizmosTest behaviour = (SurfaceGizmosTest)target;
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
