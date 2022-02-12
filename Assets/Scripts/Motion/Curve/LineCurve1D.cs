using Motion.Define;
using System;
using UnityEngine;

namespace Motion.Curve
{
    /// <summary>
    /// 1D路径曲线
    /// </summary>
    [Serializable]
    public class LineCurve1D
    {
        /// <summary>
        /// 起始位置
        /// </summary>
        public float Src;
        /// <summary>
        /// 终点位置
        /// </summary>
        public float Dest;

        /// <summary>
        /// x轴曲线
        /// </summary>
        public AnimationCurve CurveX;

        /// <summary>
        /// 根据百分比，获取点位置
        /// </summary>
        /// <param name="percent">0~1</param>
        /// <returns></returns>
        public float GetValue(float percent)
        {
            percent = Mathf.Clamp01(percent);

            float dt = 0;
            if (CurveX != null) dt = CurveX.Evaluate(percent);
            return CurveUtility.GetLinearCurve(Src, Dest, dt);
        }
    }
}
