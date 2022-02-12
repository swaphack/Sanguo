using Motion.Unity;
using UnityEditor;
using UnityEngine;

namespace Motion.Editor
{
    [CustomEditor(typeof(SurfaceBasisSplineBehaviour))]
    public class SurfaceBasisSplineEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            SurfaceBasisSplineBehaviour surface = (SurfaceBasisSplineBehaviour)target;
            if (GUILayout.Button("Generate", GUILayout.Height(20)))
            {
                surface.GenerateMesh();
            }
        }
    }
}
