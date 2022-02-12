using Motion;
using Motion.Curve;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Sample
{
    [Serializable]
    public struct EyeTarget
    {
        /// <summary>
        /// 对象
        /// </summary>
        public GameObject Target;
        /// <summary>
        /// 注视时间
        /// </summary>
        public float LookTime;
        /// <summary>
        /// 开始时视角度数
        /// </summary>
        public float StartAngle;
        /// <summary>
        /// 结束时视角度数
        /// </summary>
        public float EndAngle;
        /// <summary>
        /// 视角管理曲线
        /// </summary>
        public AnimationCurve TimeCure;
    }
    [RequireComponent(typeof(Camera))]
    public class CamereEye : MonoBehaviour
    {
        /// <summary>
        /// 经过时间
        /// </summary>
        private float _passedTime = 0.0f;
        /// <summary>
        /// 播放索引
        /// </summary>
        private int _curIndex = -1;
        /// <summary>
        /// 摄像机
        /// </summary>
        private Camera _camera;
        /// <summary>
        /// 是否循环
        /// </summary>
        public bool Loop = false;
        /// <summary>
        /// 目标
        /// </summary>
        public List<EyeTarget> EyeTargets = new List<EyeTarget>();

        private void Awake()
        {
            _camera = this.GetComponent<Camera>();
        }

        protected bool initTarget(out bool rotate)
        {
            rotate = false;

            if (EyeTargets.Count == 0) return false;
            if (_curIndex >= EyeTargets.Count) return false;

            if (_curIndex == -1)
            {
                _curIndex = 0;
                _passedTime = 0;
                rotate = true;
            }
            else
            {
                var curve = EyeTargets[_curIndex];
                if (_passedTime >= curve.LookTime)
                {
                    _curIndex += 1;
                    _passedTime = 0;
                    if (_curIndex >= EyeTargets.Count)
                    {
                        if(!Loop)
                        {
                            return false;
                        }
                        _curIndex = 0;
                        _passedTime = 0;
                        rotate = true;
                    }
                    rotate = true;
                }
            }

            return true;
        }

        /// <summary>
        /// 获取时间
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        protected float GetAngleScale(float dt)
        {
            if (EyeTargets.Count == 0) return dt;
            if (_curIndex >= EyeTargets.Count) return dt;
            var eyeTarget = EyeTargets[_curIndex];
            var timeCurve = eyeTarget.TimeCure;
            if (timeCurve == null) return dt;
            float percent = dt / eyeTarget.LookTime;
            float timeScale = timeCurve.Evaluate(percent);
            float value = CurveUtility.GetLinearCurve(eyeTarget.StartAngle, eyeTarget.EndAngle, timeScale);
            return value;
        }

        public void Update()
        {
            bool rotate = false;
            if (initTarget(out rotate))
            {
                float dt = Time.deltaTime;
                _passedTime += dt;
                var eyeTarget = EyeTargets[_curIndex];
                if (eyeTarget.Target != null)
                {
                    this.transform.LookAt(eyeTarget.Target.transform, this.transform.up);
                }
                if (_camera != null)
                {
                    _camera.fieldOfView = GetAngleScale(_passedTime);
                }
            }            
        }
    }
}
