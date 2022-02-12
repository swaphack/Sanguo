
using UnityEngine;

namespace Motion.Curve
{
    /// <summary>
    /// 曲面
    /// </summary>
    public interface ICurvedSurface
    {
        /// <summary>
        /// 获取网格
        /// </summary>
        /// <param name="sampleCount">采样信息</param>
        /// <returns></returns>
        Mesh GetMesh(int sampleCount);
    }
}
