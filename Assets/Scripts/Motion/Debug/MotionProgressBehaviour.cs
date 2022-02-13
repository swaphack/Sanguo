using Motion.Unity;
using System.Collections;
using UnityEngine;

namespace Motion.Debug
{
    /// <summary>
    /// 进度控制 控制MotionTimeBehaviour
    /// </summary>
    public class MotionProgressBehaviour : MonoBehaviour
    {
        /// <summary>
        /// 运动行为
        /// </summary>
        private MotionTimeBehaviour _motion;
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
                var motion = GetMotion();
                if (motion == null) return;
                _motion.SetPercent(_percent);
            }
        }

        protected MotionTimeBehaviour GetMotion()
        {
            if (_motion == null)
            { 
                _motion = this.GetComponent<MotionTimeBehaviour>();
            }
            return _motion;
        }
    }
}