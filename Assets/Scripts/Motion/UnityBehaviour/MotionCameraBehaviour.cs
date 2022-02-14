using Motion.Curve;
using UnityEngine;


namespace Motion.UnityBehaviour
{
    /// <summary>
    /// 摄像机曲线行为
    /// </summary>
    public class MotionCameraBehaviour : MotionBehaviour
    {
        /// <summary>
        /// 路径
        /// </summary>
        public LineCurve3D PathCurve;
        /// <summary>
        /// 转向曲线
        /// </summary>
        public AngleCurve AngleCurve;
        /// <summary>
        /// 变换体曲线
        /// </summary>
        public TransformCurve TransformCurve;
        public MotionCameraBehaviour()
        {
            UpdateEvent += Curve3DBehaviour_UpdateEvent;
        }

        /// <summary>
        /// 更新事件
        /// </summary>
        /// <param name="percent"></param>
        private void Curve3DBehaviour_UpdateEvent(float percent)
        {
            if (PathCurve != null)
            {
                this.transform.position = PathCurve.GetValue(percent);
            }

            if (TransformCurve != null)
            {
                if (TransformCurve.isEnable(percent))
                {
                    this.transform.LookAt(TransformCurve.Transform);
                    return;
                }
            }

            if (AngleCurve != null)
            {
                this.transform.rotation = Quaternion.Euler(AngleCurve.GetValue(percent));
            }
        }

        /// <summary>
        /// 获取运动坐标点
        /// </summary>
        /// <param name="percent"></param>
        /// <returns></returns>
        public override Vector3 GetMotionPoint(float percent)
        {
            if (PathCurve == null) return Vector3.zero;
            return PathCurve.GetValue(percent);
        }
    }
}
