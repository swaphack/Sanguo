using System;
using UnityEngine;

namespace Motion.Curve
{
    /// <summary>
    /// 角度曲线
    /// </summary>
    [Serializable]
    public class AngleCurve
    {
        /// <summary>
        /// 起始角度
        /// </summary>
        public Vector3 Src;
        /// <summary>
        /// 终止角度
        /// </summary>
        public Vector3 Dest;

        /// <summary>
        /// x轴曲线
        /// </summary>
        public AnimationCurve CurveX;
        /// <summary>
        /// y轴曲线
        /// </summary>
        public AnimationCurve CurveY;
        /// <summary>
        /// z轴曲线
        /// </summary>
        public AnimationCurve CurveZ;

        /// <summary>
        /// 根据百分比获取时间
        /// </summary>
        /// <param name="percent"></param>
        /// <returns></returns>
        public Vector3 GetValue(float percent)
        {
            percent = Mathf.Clamp01(percent);

            Vector3 dt = Vector3.zero;
            if (CurveX != null) dt.x = CurveX.Evaluate(percent);
            if (CurveY != null) dt.y = CurveY.Evaluate(percent);
            if (CurveZ != null) dt.z = CurveZ.Evaluate(percent);
            return new Vector3(CurveUtility.GetLinearCurve(Src.x, Dest.x, dt.x),
                CurveUtility.GetLinearCurve(Src.y, Dest.y, dt.y),
                CurveUtility.GetLinearCurve(Src.z, Dest.z, dt.z));
        }
    }
}
