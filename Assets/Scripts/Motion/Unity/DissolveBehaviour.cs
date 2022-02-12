using Motion.Curve;
using Motion.Dissolve;
using System;
using UnityEngine;

namespace Motion.Unity
{
    /// <summary>
    /// 消溶行为（unity)
    /// </summary>
    public class DissolveBehaviour : MotionTimeBehaviour
    {
        public delegate void UpdateDelegate(float percent);

        /// <summary>
        /// 进度事件
        /// </summary>
        public event UpdateDelegate UpdateEvent;
        /// <summary>
        /// 材质
        /// </summary>
        private Material _material;

        protected Material GetMaterial()
        {
            if(_material == null)
            {
                var meshRenderer = this.GetComponent<MeshRenderer>();
                if (meshRenderer == null) return null;
                _material = meshRenderer.material;
            }
            return _material;
        }

        public override void OnUpdatePercent(float percent)
        {
            percent = Mathf.Clamp01(percent);
            SetPercent(percent);
        }

        /// <summary>
        /// 设置百分比
        /// </summary>
        /// <param name="percent"></param>
        public void SetPercent(float percent)
        {
            if (UpdateEvent != null)
            {
                UpdateEvent(percent);
            }
        }

        /// <summary>
        /// 获取剔除值
        /// </summary>
        /// <param name="percent"></param>
        /// <returns></returns>
        protected virtual float GetCutOffValue(float percent)
        {
            return percent;
        }

        /// <summary>
        /// 设置阈值百分比
        /// </summary>
        /// <param name="thresholdName"></param>
        /// <param name="percent"></param>
        public void SetThresholdPercent(String thresholdName, float percent)
        {
            if (GetMaterial() == null) return;
            float value = GetCutOffValue(percent);
            GetMaterial().SetFloat(thresholdName, value);
        }
    }
}
