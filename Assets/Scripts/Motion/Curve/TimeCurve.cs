using System;
using UnityEngine;

namespace Motion.Curve
{
    /// <summary>
    /// 时间曲线
    /// </summary>
    [Serializable]
    public class TimeCurve
    {
        /// <summary>
        /// 总时长
        /// </summary>
        public float TotalTime;

        /// <summary>
        /// 曲线
        /// </summary>
        public AnimationCurve Curve;

        /// <summary>
        /// 获取时间的
        /// </summary>
        /// <param name="percent"></param>
        /// <returns></returns>
        public float GetValue(float percent)
        {
            percent = Mathf.Clamp01(percent);

            if (Curve != null) percent = Curve.Evaluate(percent);
            return percent * TotalTime;
        }

        /// <summary>
        /// 获取百分比
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public float GetPercent(float dt)
        {
            if (TotalTime <= 0) return 1;

            float percent = dt / TotalTime;
            percent = Mathf.Clamp01(percent);

            if (Curve != null) percent = Curve.Evaluate(percent);
            return percent;
        }
    }
}
