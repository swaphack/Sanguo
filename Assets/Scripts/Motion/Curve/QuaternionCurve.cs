using System;
using UnityEngine;

namespace Motion.Curve
{
    /// <summary>
    /// 四元组曲线
    /// </summary>
    [Serializable]
    public class QuaternionCurve
    {
        /// <summary>
        /// 起始角度
        /// </summary>
        public Quaternion Src;
        /// <summary>
        /// 终止角度
        /// </summary>
        public Quaternion Dest;

        /// <summary>
        /// 曲线
        /// </summary>
        public AnimationCurve Curve;

        /// <summary>
        /// 根据百分比获取时间
        /// </summary>
        /// <param name="percent"></param>
        /// <returns></returns>
        public Quaternion GetValue(float percent)
        {
            percent = Mathf.Clamp01(percent);

            if (Curve != null) percent = Curve.Evaluate(percent);
            return Quaternion.Slerp(Src, Dest, percent);
        }
    }
}
