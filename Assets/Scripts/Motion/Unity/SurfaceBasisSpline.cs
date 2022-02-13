using Motion.Curve;
using Motion.CurvedSurface;
using UnityEngine;

namespace Motion.Unity
{
    /// <summary>
    /// B样条表面
    /// </summary>
    public class SurfaceBasisSpline : SurfaceBehaviour
    {
        public BasisSpline Spline;

        public SurfaceBasisSpline()
        {
        }

        /// <summary>
        /// 获取曲面
        /// </summary>
        /// <returns></returns>
        public override ICurvedSurface GetSurface()
        {
            return Spline;
        }
    }
}
