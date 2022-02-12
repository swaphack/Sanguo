using Motion.Curve;
using System;
using UnityEngine;

namespace Motion.Unity
{
    /// <summary>
    /// 表面
    /// </summary>
    public class SurfaceBehaviour : MonoBehaviour
    {
        /// <summary>
        /// 采样状态
        /// </summary>
        public int SampleCount;
        /// <summary>
        /// 采样数
        /// </summary>
        public const int DefaultSampleCount = 100;

        /// <summary>
        /// 设置网格信息
        /// </summary>
        /// <param name="mesh"></param>
        public void SetMesh(Mesh mesh)
        {
            var meshFilter = this.GetComponent<MeshFilter>();
            if (meshFilter == null)
            {
                return;
            }
            meshFilter.mesh = mesh;
        }

        /// <summary>
        /// 获取曲面
        /// </summary>
        /// <returns></returns>
        public virtual ICurvedSurface GetSurface()
        {
            return null;
        }

        /// <summary>
        /// 生成网格
        /// </summary>
        public void GenerateMesh()
        {
            var surface = GetSurface();
            if (surface == null) return;

            int sampleCount = DefaultSampleCount;
            if (SampleCount > 0)
            {
                sampleCount = SampleCount;
            }

            var mesh = surface.GetMesh(sampleCount);
            if (mesh)
            {
                this.SetMesh(mesh);
            }
        }
    }
}
