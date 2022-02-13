using UnityEngine;
using Motion.Curve;
using System;

namespace Motion.Unity
{
    /// <summary>
    /// 运动行为（unity)
    /// </summary>
    public class MotionBehaviour : MotionTimeBehaviour
    {
        /// <summary>
        /// 获取运动坐标点
        /// </summary>
        /// <param name="percent"></param>
        /// <returns></returns>
        public virtual Vector3 GetMotionPoint(float percent)
        {
            return Vector3.zero;
        }
    }
}
