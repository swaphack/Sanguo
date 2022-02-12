using System;
using UnityEngine;

namespace Motion.Curve
{
    /// <summary>
    /// 变换体曲线
    /// 单值超过固定值才生效
    /// </summary>
    [Serializable]
    public class TransformCurve
    {
        /// <summary>
        /// 变换体
        /// </summary>
        public Transform Transform;
        /// <summary>
        /// 阈值
        /// </summary>
        [Range(0.0f, 1.0f)]
        public float Threshold = 0.5f;
        /// <summary>
        /// 曲线
        /// </summary>
        public AnimationCurve Curve;

        /// <summary>
        /// 获取时间的
        /// </summary>
        /// <param name="percent"></param>
        /// <returns></returns>
        public bool isEnable(float percent)
        {
            percent = Mathf.Clamp01(percent);

            if (Curve != null) percent = Curve.Evaluate(percent);
            return percent >= Threshold;
        }
    }
}
