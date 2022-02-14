using Motion.Curve;
using Motion.Dissolve;
using System;
using UnityEngine;

namespace Motion.UnityBehaviour
{
    /// <summary>
    /// 按照方向消失（unity)
    /// </summary>
    public class DissolveDirectionBehaviour : DissolveBehaviour
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
        /// 方向名称
        /// </summary>
        public String ShaderDirectionName;
        /// <summary>
        /// 最小阈值
        /// </summary>
        public float MinThreshold;
        /// <summary>
        /// 最大阈值
        /// </summary>
        public float MaxThreshold;
        /// <summary>
        /// 消失方向
        /// </summary>
        public DissolveDirection Direction;
        /// <summary>
        /// 反转效果
        /// </summary>
        public bool ReverseEffect;

        public DissolveDirectionBehaviour()
        {
            UpdateEvent += DissolveDirectionBehaviour_UpdateEvent;
        }

        /// <summary>
        /// 更新时间
        /// </summary>
        /// <param name="percent"></param>
        private void DissolveDirectionBehaviour_UpdateEvent(float percent)
        {
            this.SetThresholdPercent(ShaderThresholdName, percent);
            this.SetDirection(Direction);
            this.SetReverseEffect(ReverseEffect);
        }

        /// <summary>
        /// 获取剔除值
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
        /// 设置方向
        /// </summary>
        /// <param name="direction"></param>
        public void SetDirection(DissolveDirection direction)
        {
            Direction = direction;
            if (GetMaterial() != null)
            {
                GetMaterial().SetInteger(ShaderDirectionName, (int)Direction);
            }
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
