using Motion.UnityBehaviour;
using UnityEngine;

namespace Motion.Debug
{
    /// <summary>
    /// 表面行为测试
    /// </summary>
    public class SurfaceGizmosTest : MotionStatusBehaviour
    {
        /// <summary>
        /// 表面行为
        /// </summary>
        private SurfaceBehaviour _surface;

        /// <summary>
        /// 采样状态
        /// </summary>
        public int SampleCount;
        /// <summary>
        /// 采样数
        /// </summary>
        public const int DefaultSampleCount = 100;

        /// <summary>
        /// 表面行为
        /// </summary>
        /// <returns></returns>
        public SurfaceBehaviour GetSurface()
        {
            if (_surface == null)
            {
                _surface = this.GetComponent<SurfaceBehaviour>();
            }
            return _surface;
        }

        /// <summary>
        /// 绘制表面
        /// </summary>
        protected void DrawGizmosSurface()
        {
            var behaviour = GetSurface();
            if (behaviour == null) return;
            var surface = behaviour.GetSurface();
            if (surface == null) return;

            int sampleCount = DefaultSampleCount;
            if (SampleCount > 0)
            {
                sampleCount = SampleCount;
            }

            var mesh = surface.GetMesh(sampleCount);
            if (mesh)
            {
                Gizmos.DrawMesh(mesh, behaviour.transform.position, behaviour.transform.rotation);
            }
        }

        /// <summary>
        /// 选中
        /// </summary>
        private void OnDrawGizmosSelected()
        {
            if (!IsEnable) return;

            DrawGizmosSurface();
        }

    }
}
