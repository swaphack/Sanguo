
using Motion.Curve;
using System;

namespace Motion.UnityBehaviour
{
    /// <summary>
    /// 按照灰度纹理消失（unity)
    /// </summary>
    public class DissolveTextureBehaviour : DissolveBehaviour
    {
        /// <summary>
        /// 阈值名称
        /// </summary>
        public String ShaderThresholdName;
        /// <summary>
        /// 反转名称
        /// </summary>
        public String ShaderReverseName;
        /// <summary>
        /// 最小阈值
        /// </summary>
        public float MinThreshold;
        /// <summary>
        /// 最大阈值
        /// </summary>
        public float MaxThreshold = 1;

        /// <summary>
        /// 反转效果
        /// </summary>
        public bool ReverseEffect;

        public DissolveTextureBehaviour()
        {
            UpdateEvent += DissolveTextureBehaviour_UpdateEvent;
        }

        private void DissolveTextureBehaviour_UpdateEvent(float percent)
        {
            this.SetThresholdPercent(ShaderThresholdName, percent);
            this.SetReverseEffect(ReverseEffect);
        }

        /// <summary>
        /// 设置裁剪值
        /// </summary>
        /// <param name="percent"></param>
        /// <returns></returns>
        protected override float GetCutOffValue(float percent)
        {
            float min = MinThreshold;
            float max = MaxThreshold;
            return CurveUtility.GetLinearCurve(min, max, percent);
        }

        /// <summary>
        /// 反转特效
        /// </summary>
        /// <param name="reverse"></param>
        public void SetReverseEffect(bool reverse)
        {
            ReverseEffect = reverse;
            if (GetMaterial() != null)
            {
                GetMaterial().SetInteger(ShaderReverseName, ReverseEffect ? 1 : 0);
            }
        }
    }
}
