﻿
using Motion.Unity;
using UnityEditor;
using UnityEngine;

namespace Motion.Editor
{
    [CustomEditor(typeof(DissolveDirectionBehaviour))]
    public class DissolveDirectionEditor : UnityEditor.Editor
    {
        bool enable = false;
        float percent = 0;
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            DissolveDirectionBehaviour dissolve = (DissolveDirectionBehaviour)target;
            GUILayout.BeginHorizontal(GUILayout.Height(20));
            GUILayout.Label("Enable:", GUILayout.MaxWidth(100));
            enable = GUILayout.Toggle(enable, "Enable Editor Progress:");
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal(GUILayout.Height(20));
            GUILayout.Label("Progress:", GUILayout.MaxWidth(100));
            float value = GUILayout.HorizontalSlider(percent, 0, 1);
            if (enable)
            {
                percent = value;
                dissolve.SetPercent(percent);
            }
            GUILayout.EndHorizontal();

        }
    }
}
