using Motion;
using Motion.Deprecated;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample
{
    /// <summary>
    /// �˶�����
    /// </summary>
    [Serializable]
    public struct MotionCurve
    {
        /// <summary>
        /// ��������
        /// </summary>
        public CurveMode CurveMode;
        /// <summary>
        /// ʱ��
        /// </summary>
        public float MotionTime;
        /// <summary>
        /// ʱ������
        /// </summary>
        public AnimationCurve TimeCurve;
        /// <summary>
        /// ��ʼ��
        /// </summary>
        public Transform Src;
        /// <summary>
        /// ������
        /// </summary>
        public Transform Dest;
        /// <summary>
        /// ���Ƶ�
        /// </summary>
        public List<Transform> Controllers;
    }

    public class CameraMotion : MonoBehaviour
    {
        /// <summary>
        /// ����ʱ��
        /// </summary>
        private float _passedTime = 0.0f;
        /// <summary>
        /// ��������
        /// </summary>
        private int _curveIndex = -1;
        /// <summary>
        /// �˶���
        /// </summary>
        private Track _motionBody = new Track();
        /// <summary>
        /// �Ƿ�ѭ��
        /// </summary>
        public bool Loop = false;
        /// <summary>
        /// �˶�����
        /// </summary>
        public List<MotionCurve> Curves = new List<MotionCurve>();

        public CameraMotion()
        {
            _motionBody.PointEvent += _motionBody_PointEvent;
        }

        private void _motionBody_PointEvent(Vector3 position)
        {
            this.transform.position = position;
        }

        // Start is called before the first frame update
        void Start()
        {
        }

        bool initPath()
        {
            if (Curves.Count == 0) return false;
            if (_curveIndex >= Curves.Count) return false;

            bool bInitPath = false;
            if (_curveIndex == -1)
            {
                _curveIndex = 0;
                _passedTime = 0;
                bInitPath = true;
            }
            else
            {
                var curve = Curves[_curveIndex];
                if (_passedTime >= curve.MotionTime)
                {
                    _curveIndex += 1;
                    _passedTime = 0;
                    if (_curveIndex >= Curves.Count)
                    {
                        if (!Loop) return false;
                        _curveIndex = 0;
                        _passedTime = 0;
                    }
                    bInitPath = true;
                }
            }


            if (_motionBody != null && bInitPath)
            {
                _motionBody.Reset();

                var curve = Curves[_curveIndex];
                if (curve.Src != null && curve.Dest != null)
                {
                    List<Vector3> controlPoints = new List<Vector3>();
                    if (curve.Controllers != null)
                    {
                        foreach(var item in curve.Controllers)
                        {
                            if (item != null)
                            {
                                controlPoints.Add(item.position);
                            }
                        }
                    }
                    _motionBody.SetPath(curve.CurveMode, curve.MotionTime, curve.Src.position, curve.Dest.position, controlPoints);
                }
            }
            return true;
        }

        /// <summary>
        /// ��ȡʱ��
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        protected float GetTimeScale(float dt)
        {
            if (Curves.Count == 0) return dt;
            if (_curveIndex >= Curves.Count) return dt;
            var curve = Curves[_curveIndex];
            var timeCurve = curve.TimeCurve;
            if (timeCurve == null) return dt;
            float percent = dt / curve.MotionTime;
            float timeScale = timeCurve.Evaluate(percent);
            return timeScale * curve.MotionTime;
        }

        // Update is called once per frame
        void Update()
        {
            if (initPath())
            {
                float dt = Time.deltaTime;
                float lastTime = _passedTime;
                float newTime = _passedTime + dt;
                lastTime = GetTimeScale(lastTime);
                newTime = GetTimeScale(newTime);
                float newdt = newTime - lastTime;
                _passedTime += dt;
                _motionBody.Step(newdt);
            }
        }
    }
}