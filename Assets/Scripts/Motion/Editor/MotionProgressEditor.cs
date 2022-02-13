using Motion.Debug;
using UnityEditor;
using UnityEngine;

namespace Motion.Editor
{
    /// <summary>
    /// 进度控制
    /// </summary>
    [CustomEditor(typeof(MotionProgressBehaviour))]
    public class MotionProgressEditor : UnityEditor.Editor
    {
        private bool _bEnable = true;

        [MenuItem("Tools/MyTool/Do It in C#")]
        public override void OnInspectorGUI()
        {
            MotionProgressBehaviour dissolve = (MotionProgressBehaviour)target;
            GUILayout.BeginHorizontal(GUILayout.Height(20));
            GUILayout.Label("Enable:", GUILayout.MaxWidth(100));
            _bEnable = GUILayout.Toggle(_bEnable, "Enable Editor Progress:");
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal(GUILayout.Height(20));
            GUILayout.Label("Progress:", GUILayout.MaxWidth(100));
            float value = GUILayout.HorizontalSlider(dissolve.Percent, 0, 1);
            if (_bEnable)
            {
                dissolve.Percent = value;
            }
            GUILayout.EndHorizontal();
        }
    }
}