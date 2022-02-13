using Motion.Unity;
using System.Collections;
using UnityEngine;

namespace Motion.Debug
{
    /// <summary>
    /// 进度控制 控制MotionTimeBehaviour
    /// </summary>
    public class MotionProgressTest : MotionStatusBehaviour
    {
        /// <summary>
        /// 运动时间行为
        /// </summary>
        private MotionTimeBehaviour _motionTime;
        /// <summary>
        /// 百分比
        /// </summary>
        private float _percent;

        /// <summary>
        /// 百分比
        /// </summary>
        public float Percent 
        { 
            get
            {
                return _percent;
            }
            set
            {
                _percent = value;
                var motion = GetMotionTime();
                if (motion == null) return;
                _motionTime.SetPercent(_percent);
            }
        }

        /// <summary>
        /// 运动时间行为
        /// </summary>
        /// <returns></returns>
        protected MotionTimeBehaviour GetMotionTime()
        {
            if (_motionTime == null)
            { 
                _motionTime = this.GetComponent<MotionTimeBehaviour>();
            }
            return _motionTime;
        }
    }
}