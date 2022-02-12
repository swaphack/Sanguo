using UnityEngine;

namespace Motion.Define
{
    /// <summary>
    /// 路径片段，只包含起点和终点
    /// </summary>
    public class PathSegment
    {
        /// <summary>
        /// 起点
        /// </summary>
        public Vector3 Source { get; set; } = new Vector3();
        /// <summary>
        /// 终点
        /// </summary>
        public Vector3 Destination { get; set; } = new Vector3();

        public PathSegment()
        {

        }

        public PathSegment(Vector3 src, Vector3 dest)
        {
            Source = src;
            Destination = dest;
        }
    }
}
