using UnityEngine;
using Motion.Curve;
using System;

namespace Motion.Unity
{
    /// <summary>
    /// 运动行为测试
    /// </summary>
    public class MotionDebugBehaviour : MonoBehaviour
    {
        /// <summary>
        /// Gizoms 是否开启
        /// </summary>
        public bool IsGizomsEnable;
        /// <summary>
        /// 绘制次数
        /// </summary>
        public int GizomsDrawCount;
        /// <summary>
        /// 默认绘制数量
        /// </summary>
        public const int DefaultGizmosDrawCount = 100;

        /// <summary>
        /// gizmos绘制
        /// </summary>
        protected void DrawGizmosLines()
        {
            int totalCount = DefaultGizmosDrawCount;
            if (GizomsDrawCount > 0)
            {
                totalCount = GizomsDrawCount;
            }

            Vector3 lastPoint = GetGizmosPoint(0);
            for (int i = 0; i < totalCount; i++)
            {
                float percent = 1.0f * (i + 1) / totalCount;
                Vector3 point = GetGizmosPoint(percent);
                Gizmos.DrawLine(lastPoint, point);
                lastPoint = point;
            }
        }

        /// <summary>
        /// 获取gizmos坐标点
        /// </summary>
        /// <param name="percent"></param>
        /// <returns></returns>
        protected Vector3 GetGizmosPoint(float percent)
        {
            var behaviour = this.GetComponent<MotionBehaviour>();
            if (behaviour == null) return Vector3.zero;
            return behaviour.GetMotionPoint(percent);
        }

        /// <summary>
        /// 选中对象
        /// </summary>
        private void OnDrawGizmosSelected()
        {
            if (!IsGizomsEnable)
            {
                return;
            }

            DrawGizmosLines();
        }
    }
}
