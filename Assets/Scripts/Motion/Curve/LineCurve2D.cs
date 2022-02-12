using Motion.Define;
using System;
using UnityEngine;

namespace Motion.Curve
{
    /// <summary>
    /// 2D路径曲线
    /// </summary>
    [Serializable]
    public class LineCurve2D
    {
        /// <summary>
        /// 起始位置
        /// </summary>
        public Vector2 Src;
        /// <summary>
        /// 终点位置
        /// </summary>
        public Vector2 Dest;

        /// <summary>
        /// x轴曲线
        /// </summary>
        public AnimationCurve CurveX;
        /// <summary>
        /// y轴曲线
        /// </summary>
        public AnimationCurve CurveY;

        /// <summary>
        /// 根据百分比，获取点位置
        /// </summary>
        /// <param name="percent">0~1</param>
        /// <returns></returns>
        public Vector2 GetValue(float percent)
        {
            percent = Mathf.Clamp01(percent);

            Vector2 dt = Vector2.zero;
            if (CurveX != null) dt.x = CurveX.Evaluate(percent);
            if (CurveY != null) dt.y = CurveY.Evaluate(percent);
            return new Vector2(CurveUtility.GetLinearCurve(Src.x, Dest.x, dt.x),
                CurveUtility.GetLinearCurve(Src.y, Dest.y, dt.y));
        }
    }
}
