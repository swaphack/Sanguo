using Motion.Curve;
using Motion.Define;
using System.Collections.Generic;
using UnityEngine;

namespace Motion.Deprecated
{
    /// <summary>
    /// 轨迹
    /// </summary>
    public class Track
    {
        public delegate void PonitDelegate(Vector3 position);

        /// <summary>
        /// 路径段
        /// </summary>
        public PathSegment Segment { get; private set; } = new PathSegment();
        /// <summary>
        /// 曲线类型
        /// </summary>
        public CurveMode Mode { get; private set; } = CurveMode.Linear;
        /// <summary>
        /// 总时间
        /// </summary>
        public float TotalTime { get; private set; } = 1.0f;
        /// <summary>
        /// 已经过时间
        /// </summary>
        public float PassedTime { get; private set; } = 0.0f;
        /// <summary>
        /// 控制点
        /// </summary>
        public List<Vector3> ControlPoints { get; private set; } = new List<Vector3>();
        /// <summary>
        /// 点处理
        /// </summary>
        public event PonitDelegate PointEvent;

        public Track()
        {

        }

        /// <summary>
        /// 设置路线
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="dt"></param>
        /// <param name="src"></param>
        /// <param name="dest"></param>
        /// <param name="controlPoints"></param>
        public void SetPath(CurveMode mode, float dt, Vector3 src, Vector3 dest, List<Vector3> controlPoints)
        {
            Mode = mode;
            Segment.Source = src;
            Segment.Destination = dest;
            TotalTime = dt;
            ControlPoints = controlPoints;
        }

        /// <summary>
        /// 设置路线
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="dt"></param>
        /// <param name="src"></param>
        /// <param name="dest"></param>
        /// <param name="controlPoints"></param>
        public void SetPath(CurveMode mode, float dt, Vector3 src, Vector3 dest, params Vector3[] controlPoints)
        {
            List<Vector3> points = new List<Vector3>();
            if (controlPoints.Length > 0)
            {
                for(int i = 0; i < controlPoints.Length; i++)
                {
                    points.Add(controlPoints[i]);
                }
            }

            SetPath(mode, dt, src, dest, points);
        }

        /// <summary>
        /// 重置
        /// </summary>
        public void Reset()
        {
            PassedTime = 0;
        }

        /// <summary>
        /// 反转
        /// </summary>
        /// <returns></returns>
        public Track Reverse()
        {
            var track = new Track();
            track.Segment.Source = Segment.Destination;
            track.Segment.Destination = Segment.Destination;
            track.ControlPoints.AddRange(ControlPoints);
            track.ControlPoints.Reverse();

            track.TotalTime = TotalTime;
            track.Mode = Mode;
            return track;
        }

        /// <summary>
        /// 按照进度，获取曲线点
        /// </summary>
        /// <param name="percent">0~1</param>
        /// <returns></returns>
        public Vector3 GetPointWithPercent(float percent)
        {
            Vector3 point = Segment.Source;
            if (Mode == CurveMode.Linear)
            {
                point = CurveUtility.GetLinearCurve(Segment.Source, Segment.Destination, percent);
            }
            else if (Mode == CurveMode.Bezier2)
            {
                if (ControlPoints != null && ControlPoints.Count >= 1)
                {
                    point = CurveUtility.GetBezierCurve(Segment.Source, ControlPoints[0], Segment.Destination, percent);
                }
            }
            else if (Mode == CurveMode.Bezier3)
            {
                if (ControlPoints != null && ControlPoints.Count >= 2)
                {
                    point = CurveUtility.GetBezierCurve(Segment.Source, ControlPoints[0], ControlPoints[1], Segment.Destination, percent);
                }
            }

            return point;
        }

        /// <summary>
        /// 按照时间，获取曲线点
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public Vector3 GetPointWithTime(float time)
        {
            float percent = time / TotalTime;
            return GetPointWithPercent(percent);
        }

        /// <summary>
        /// 步进
        /// </summary>
        /// <param name="dt"></param>
        public void Step(float dt)
        {
            if (PassedTime >= TotalTime)
            { 
                return;
            }

            PassedTime += dt;
            if (PassedTime > TotalTime)
            { 
                PassedTime = TotalTime;
            }
            if (PointEvent != null)
            {
                float percent = PassedTime / TotalTime;
                Vector3 point = GetPointWithPercent(percent);
                PointEvent(point);
            }
        }
    }
}
