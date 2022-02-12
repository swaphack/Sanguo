using UnityEngine;
using System;
using Motion.Curve;

namespace Motion.CurvedSurface
{
    /// <summary>
    /// B样条
    /// </summary>
    [Serializable]
    public class BasisSpline : ICurvedSurface
    {
        public Vector3 SrcPoint1;
        public Vector3 SrcPoint2;
        public Vector3 DestPoint1;
        public Vector3 DestPoint2;

        /// <summary>
        /// x轴曲线
        /// </summary>
        public AnimationCurve CurveX;
        /// <summary>
        /// y轴曲线
        /// </summary>
        public AnimationCurve CurveY;
        /// <summary>
        /// z轴曲线
        /// </summary>
        public AnimationCurve CurveZ;

        /// <summary>
        /// 根据百分比，获取从SrcPoint1到DestPoint1点位置
        /// </summary>
        /// <param name="percent">0~1</param>
        /// <returns></returns>
        public Vector3 GetValue1(float percent)
        {
            percent = Mathf.Clamp01(percent);

            Vector3 dt = Vector3.zero;
            if (CurveX != null) dt.x = CurveX.Evaluate(percent);
            if (CurveY != null) dt.y = CurveY.Evaluate(percent);
            if (CurveZ != null) dt.z = CurveZ.Evaluate(percent);
            return new Vector3(CurveUtility.GetLinearCurve(SrcPoint1.x, DestPoint1.x, dt.x),
                CurveUtility.GetLinearCurve(SrcPoint1.y, DestPoint1.y, dt.y),
                CurveUtility.GetLinearCurve(SrcPoint1.z, DestPoint1.z, dt.z));
        }

        /// <summary>
        /// 根据百分比，获取从SrcPoint2到DestPoint2点位置
        /// </summary>
        /// <param name="percent">0~1</param>
        /// <returns></returns>
        public Vector3 GetValue2(float percent)
        {
            percent = Mathf.Clamp01(percent);

            Vector3 dt = Vector3.zero;
            if (CurveX != null) dt.x = CurveX.Evaluate(percent);
            if (CurveY != null) dt.y = CurveY.Evaluate(percent);
            if (CurveZ != null) dt.z = CurveZ.Evaluate(percent);
            return new Vector3(CurveUtility.GetLinearCurve(SrcPoint2.x, DestPoint2.x, dt.x),
                CurveUtility.GetLinearCurve(SrcPoint2.y, DestPoint2.y, dt.y),
                CurveUtility.GetLinearCurve(SrcPoint2.z, DestPoint2.z, dt.z));
        }

        /// <summary>
        /// 获取网格
        /// </summary>
        /// <param name="divideCount"></param>
        /// <returns></returns>
        public Mesh GetMesh(int divideCount)
        {
            Vector3[] vertices = new Vector3[2 * divideCount + 2];
            for(int i = 0; i <= divideCount; i++)
            {
                float percent = 1.0f * i / divideCount;
                Vector3 point1 = GetValue1(percent);
                Vector3 point2 = GetValue2(percent);

                vertices[2 * i + 0] = point1;
                vertices[2 * i + 1] = point2;
            }

            Vector2[] uv = new Vector2[2 * divideCount + 2];
            for (int i = 0; i <= divideCount; i++)
            {
                float percent = 1.0f * i / divideCount;
                Vector2 uv1 = new Vector2(percent, 0);
                Vector2 uv2 = new Vector2(percent, 1);
                uv[2 * i + 0] = uv1;
                uv[2 * i + 1] = uv2;
            }

            int[] triangles = new int[3 * 2 * divideCount];
            for (int i = 0; i < divideCount; i++)
            {
                triangles[6 * i + 0] = 2 * i;
                triangles[6 * i + 1] = 2 * i + 1;
                triangles[6 * i + 2] = 2 * i + 3;

                triangles[6 * i + 3] = 2 * i;
                triangles[6 * i + 4] = 2 * i + 3;
                triangles[6 * i + 5] = 2 * i + 2;
            }

            Mesh mesh = new Mesh();
            mesh.name = this.GetType().Name;
            mesh.vertices = vertices;
            mesh.triangles = triangles;
            mesh.uv = uv;
            return mesh;
        }
    }
}

