using UnityEngine;

namespace Motion.UnityBehaviour
{
    /// <summary>
    /// 运动时间
    /// </summary>
    public class MotionTimeBehaviour : MonoBehaviour
    {

        public delegate void UpdateDelegate(float percent);
        /// <summary>
        /// 当前时间
        /// </summary>
        private float currentTime = 0;
        /// <summary>
        /// 是否循环
        /// </summary>
        public bool IsLoop;
        /// <summary>
        /// 反转时间
        /// </summary>
        public bool ReverseTime;
        /// <summary>
        /// 总时间
        /// </summary>
        public float TotalTime = 5;
        /// <summary>
        /// 时间曲线
        /// </summary>
        public AnimationCurve TimeCurve;

        /// <summary>
        /// 进度事件
        /// </summary>
        public event UpdateDelegate UpdateEvent;

        private void Update()
        {
            float dt = Time.deltaTime;
            currentTime += dt;
            float percent = GetPercent();
            OnUpdatePercent(percent);

            if (IsLoop)
            {
                if (currentTime >= TotalTime)
                {
                    currentTime = 0;
                }
            }
        }

        /// <summary>
        /// 获取百分比
        /// </summary>
        /// <returns></returns>
        private float GetPercent()
        {
            float percent = 1;
            if (TotalTime > 0) percent = currentTime / TotalTime;
            if (ReverseTime) percent = 1 - percent;
            percent = Mathf.Clamp01(percent);
            if (TimeCurve != null)
            {
                percent = TimeCurve.Evaluate(percent);
            }
            
            return percent;
        }

        /// <summary>
        /// 更新进度
        /// </summary>
        /// <param name="percent"></param>
        public void OnUpdatePercent(float percent)
        {
            percent = Mathf.Clamp01(percent);
            SetPercent(percent);
        }

        /// <summary>
        /// 设置百分比
        /// </summary>
        /// <param name="percent"></param>
        public void SetPercent(float percent)
        {
            if (UpdateEvent != null)
            {
                UpdateEvent(percent);
            }
        }

        /// <summary>
        /// 重置
        /// </summary>
        public void Reset()
        {
            currentTime = 0;
        }
    }
}
