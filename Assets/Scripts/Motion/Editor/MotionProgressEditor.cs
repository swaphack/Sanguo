using Motion.Debug;
using UnityEditor;
using UnityEngine;

namespace Motion.Editor
{
    /// <summary>
    /// 进度控制
    /// </summary>
    [CustomEditor(typeof(MotionTimeTest))]
    public class MotionProgressEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            MotionTimeTest progress = (MotionTimeTest)target;

            GUILayout.BeginHorizontal(GUILayout.Height(20));
            GUILayout.Label("Progress:", GUILayout.MaxWidth(100));
            float value = GUILayout.HorizontalSlider(progress.Percent, 0, 1);
            if (progress.IsEnable)
            {
                progress.Percent = value;
            }
            GUILayout.EndHorizontal();
        }
    }
}