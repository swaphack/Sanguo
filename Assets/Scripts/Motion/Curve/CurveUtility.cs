using UnityEngine;

namespace Motion.Curve
{
    /// <summary>
    /// 曲线工具
    /// </summary>
    public class CurveUtility
    {
        /// <summary>
        /// 线性曲线
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dest"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static float GetLinearCurve(float src, float dest, float t)
        {
            return (1 - t) * src + t * dest;
        }

        /// <summary>
        /// 线性曲线
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dest"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static Vector3 GetLinearCurve(Vector3 src, Vector3 dest, float t)
        {
            return (1 - t) * src + t * dest;
        }

        /// <summary>
        /// 二次贝塞尔曲线
        /// </summary>
        /// <param name="src"></param>
        /// <param name="controlPoint"></param>
        /// <param name="dest"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static float GetBezierCurve(float src, float controlPoint, float dest, float t)
        {
            return Mathf.Pow(1 - t, 2) * src + 2 * t * (1 - t) * controlPoint + Mathf.Pow(t, 2) * dest;
        }

        /// <summary>
        /// 二次贝塞尔曲线
        /// </summary>
        /// <param name="src"></param>
        /// <param name="controlPoint"></param>
        /// <param name="dest"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static Vector3 GetBezierCurve(Vector3 src, Vector3 controlPoint, Vector3 dest, float t)
        {
            return Mathf.Pow(1 - t, 2) * src + 2 * t * (1 - t) * controlPoint + Mathf.Pow(t, 2) * dest;
        }


        /// <summary>
        /// 三次贝塞尔曲线
        /// </summary>
        /// <param name="src"></param>
        /// <param name="controlPoint1"></param>
        /// <param name="controlPoint2"></param>
        /// <param name="dest"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static float GetBezierCurve(float src, float controlPoint1, float controlPoint2, float dest, float t)
        {
            return Mathf.Pow(1 - t, 3) * src + 3 * t * Mathf.Pow(1 - t, 2) * controlPoint1 + 3 * Mathf.Pow(t, 2) * (1 - t) * controlPoint2 + Mathf.Pow(t, 3) * dest;
        }

        /// <summary>
        /// 三次贝塞尔曲线
        /// </summary>
        /// <param name="src"></param>
        /// <param name="controlPoint1"></param>
        /// <param name="controlPoint2"></param>
        /// <param name="dest"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static Vector3 GetBezierCurve(Vector3 src, Vector3 controlPoint1, Vector3 controlPoint2, Vector3 dest, float t)
        {
            return Mathf.Pow(1 - t, 3) * src + 3 * t * Mathf.Pow(1 - t, 2) * controlPoint1 + 3 * Mathf.Pow(t, 2) * (1 - t) * controlPoint2 + Mathf.Pow(t, 3) * dest;
        }
    }
}
