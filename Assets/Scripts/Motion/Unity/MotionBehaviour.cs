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
        public delegate void UpdateDelegate(float percent);
        
        /// <summary>
        /// 进度事件
        /// </summary>
        public event UpdateDelegate UpdateEvent;

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
