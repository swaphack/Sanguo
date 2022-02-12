using System.Collections.Generic;
using UnityEngine;

namespace Motion.Define
{
    /// <summary>
    /// ·��
    /// </summary>
    public class Path
    {
        /// <summary>
        /// ·����
        /// </summary>
        private List<Vector3> _points = new List<Vector3>();

        /// <summary>
        /// �ڵ�����
        /// </summary>
        public int PointCount => _points.Count;

        public Path()
        {

        }

        /// <summary>
        /// ��ӽڵ�
        /// </summary>
        /// <param name="point"></param>
        public void AddPoint(Vector3 point)
        {
            _points.Add(point);
        }

        /// <summary>
        /// �Ƴ��ڵ�
        /// </summary>
        /// <param name="point"></param>
        public void RemovePoint(Vector3 point)
        {
            _points.Remove(point);
        }

        /// <summary>
        /// ��ȡ�ڵ�
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
        /// �ڵ�����λ��
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public int IndexOf(Vector3 point)
        {
            return _points.IndexOf(point);
        }

        /// <summary>
        /// ��սڵ�
        /// </summary>
        public void Clear()
        {
            _points.Clear();
        }

        /// <summary>
        /// ȡ���߶Σ������ʼ���������һ�������ؿ�
        /// </summary>
        /// <param name="srcIndex">��ʼ����</param>
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
        /// ȡ���߶�,�����ʼ���������һ�����¸��ڵ�ȡ��ͷλ��
        /// </summary>
        /// <param name="srcIndex">��ʼ����</param>
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

