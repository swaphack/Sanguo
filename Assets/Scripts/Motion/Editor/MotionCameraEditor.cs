using Motion.Unity;
using UnityEditor;
using UnityEngine;

namespace Motion.Editor
{
    [CustomEditor(typeof(MotionCameraBehaviour))]
    public class MotionCameraEditor : UnityEditor.Editor
    {
        float percent = 0;
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            MotionCameraBehaviour motion = (MotionCameraBehaviour)target;
            GUILayout.BeginHorizontal(GUILayout.Height(20));
            GUILayout.Label("Progress:", GUILayout.MaxWidth(100));
            percent = GUILayout.HorizontalSlider(percent, 0, 1);
            motion.SetPercent(percent);
            GUILayout.EndHorizontal();
            
        }
    }
}
