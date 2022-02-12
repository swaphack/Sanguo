using UnityEngine;

namespace Motion.Unity
{
    /// <summary>
    /// 表面行为测试
    /// </summary>
    public class SurfaceDebugBehaviour : MonoBehaviour
    {
        /// <summary>
        /// Gizoms 是否开启
        /// </summary>
        public bool IsGizomsEnable;
        /// <summary>
        /// 采样状态
        /// </summary>
        public int SampleCount;
        /// <summary>
        /// 采样数
        /// </summary>
        public const int DefaultSampleCount = 100;

        /// <summary>
        /// 绘制表面
        /// </summary>
        protected void DrawGizmosSurface()
        {
            var behaviour = this.GetComponent<SurfaceBehaviour>();
            if (behaviour == null)
            {
                return;
            }
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
                mesh.RecalculateNormals();
                Gizmos.DrawMesh(mesh);
            }
        }

        /// <summary>
        /// 选中
        /// </summary>
        private void OnDrawGizmosSelected()
        {
            DrawGizmosSurface();
        }

    }
}
