using System.Collections.Generic;
using UnityEngine;

namespace Motion.Define
{
    /// <summary>
    /// 路径
    /// </summary>
    public class Path
    {
        /// <summary>
        /// 路径点
        /// </summary>
        private List<Vector3> _points = new List<Vector3>();

        /// <summary>
        /// 节点数量
        /// </summary>
        public int PointCount => _points.Count;

        public Path()
        {

        }

        /// <summary>
        /// 添加节点
        /// </summary>
        /// <param name="point"></param>
        public void AddPoint(Vector3 point)
        {
            _points.Add(point);
        }

        /// <summary>
        /// 移除节点
        /// </summary>
        /// <param name="point"></param>
        public void RemovePoint(Vector3 point)
        {
            _points.Remove(point);
        }

        /// <summary>
        /// 获取节点
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Vector3 GetPoint(int index)
        {
            if (index < 0 || index >= _points.Count)
                return Vector3.zero;

            return _points[index];
        }

        /// <summary>
        /// 节点所在位置
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public int IndexOf(Vector3 point)
        {
            return _points.IndexOf(point);
        }

        /// <summary>
        /// 清空节点
        /// </summary>
        public void Clear()
        {
            _points.Clear();
        }

        /// <summary>
        /// 取出线段，如果开始索引是最后一个，返回空
        /// </summary>
        /// <param name="srcIndex">开始索引</param>
        /// <returns></returns>
        public PathSegment PickSegment(int srcIndex)
        {
            if (srcIndex < 0 || srcIndex >= PointCount)
            {
                return null;
            }
            int destIndex = srcIndex + 1;
            if (destIndex >= PointCount)
            {
                return null;
            }
            Vector3 src = _points[srcIndex];
            Vector3 dest = _points[destIndex];
            return new PathSegment() { Source = src, Destination = dest };
        }

        /// <summary>
        /// 取出线段,如果开始索引是最后一个，下个节点取开头位置
        /// </summary>
        /// <param name="srcIndex">开始索引</param>
        /// <returns></returns>
        public PathSegment PickSegmentWithLoop(int srcIndex)
        {
            if (srcIndex < 0 || srcIndex >= PointCount)
            {
                return null;
            }
            Vector3 src = _points[srcIndex];
            int destIndex = srcIndex + 1;
            destIndex = destIndex % PointCount;
            Vector3 dest = _points[srcIndex];
            return new PathSegment() { Source = src, Destination = dest };
        }
    }
}

