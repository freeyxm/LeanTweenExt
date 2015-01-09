using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[System.Serializable]
public class LeanTweenCommModel
{
    [System.Serializable]
    public struct Method
    {
        public GameObject target;
        public string className;
        public string methodName;
        public string param;
    }
    [System.Serializable]
    public struct Methods
    {
        public enum ParamType
        {
            Float,
            Vector3,
            Color,
        }

        public Method onUpdate;
        public ParamType onUpdateType;

        public Method onComplete;
        public bool onCompleteOnRepeat;
        public bool onCompleteOnStart;
    }
    public Methods m_methods;

    public enum LoopType
    {
        once = LeanTweenType.once,
        clamp = LeanTweenType.clamp,
        pingPong = LeanTweenType.pingPong,
    }

    /// <summary>
    /// The time to complete the tween.
    /// </summary>
    public float m_time;

    /// <summary>
    /// Delay the start of a tween.
    /// </summary>
    public float m_delay;

    /// <summary>
    /// tween type.
    /// </summary>
    public LeanTweenType m_tweenType;

    /// <summary>
    /// only available when m_tweenType == LeanTweenType.animationCurve
    /// </summary>
    public AnimationCurve m_animationCurve;

    /// <summary>
    /// tween loop type.
    /// </summary>
    public LoopType m_loopType = LoopType.once;

    /// <summary>
    /// number of times of tween repeat.
    /// </summary>
    public int m_loopRepeat = 1;

    [System.Serializable]
    public class ExtraOptions
    {
        /// <summary>
        /// While tweening along a curve, set this property to true, to be perpendicalur to the path it is moving upon
        /// </summary>
        public bool orientPath = false;

        /// <summary>
        /// While tweening along a curve, set this property to true, to be perpendicalur to the path it is moving upon
        /// </summary>
        public bool orientPath2d = false;

        /// <summary>
        /// Use estimated time when tweening an object when you want the animation to be time-scale independent (ignores the Time.timeScale value). 
        /// Great for pause screens, when you want all other action to be stopped (or slowed down)
        /// </summary>
        public bool useEstimatedTime = false;

        /// <summary>
        /// Use useFrames when tweening an object, when you don't want the animation to be time-frame independent...
        /// </summary>
        public bool useFrames = false;

        /// <summary>
        /// Use manual time when tweening an object,
        /// </summary>
        public bool useManualTime = false;

        /// <summary>
        /// Set the point at which the GameObject will be rotated around
        /// </summary>
        public Vector3 point = Vector3.zero;
    }
    public ExtraOptions m_options;

    public virtual void DoAction(GameObject go)
    {
    }

    protected virtual void SetOptions(LTDescr ltDescr)
    {
        ltDescr.setDelay(m_delay);

        if (m_tweenType == LeanTweenType.animationCurve)
            ltDescr.setEase(m_animationCurve);
        else
            ltDescr.setEase(m_tweenType);

        ltDescr.setRepeat(m_loopRepeat);
        ltDescr.setLoopType((LeanTweenType)m_loopType);

        SetExtraOptions(ltDescr);
        BindMethods(ltDescr);
    }

    protected virtual void SetExtraOptions(LTDescr ltDescr)
    {
        if (m_options.orientPath)
            ltDescr.setOrientToPath(m_options.orientPath);
        if (m_options.orientPath2d)
            ltDescr.setOrientToPath2d(m_options.orientPath2d);
        if (m_options.useEstimatedTime)
            ltDescr.setUseEstimatedTime(m_options.useEstimatedTime);
        if (m_options.useFrames)
            ltDescr.setUseFrames(m_options.useFrames);
        if (m_options.useManualTime)
            ltDescr.setUseManualTime(m_options.useManualTime);
        if (!m_options.point.Equals(Vector3.zero))
            ltDescr.setPoint(m_options.point);
    }

    protected virtual void BindMethods(LTDescr ltDescr)
    {
        {
            Method method = m_methods.onComplete;
            object obj = null;
            System.Reflection.MethodInfo methodInfo = GetMethodInfo(method, ref obj);
            if (methodInfo != null)
            {
                ltDescr.setOnComplete(delegate()
                {
                    object[] args = { method.target, method.param };
                    methodInfo.Invoke(obj, args);
                });
                ltDescr.setOnCompleteOnRepeat(m_methods.onCompleteOnRepeat);
                ltDescr.setOnCompleteOnStart(m_methods.onCompleteOnStart);
            }
        }
        {
            Method method = m_methods.onUpdate;
            object obj = null;
            System.Reflection.MethodInfo methodInfo = GetMethodInfo(method, ref obj);
            if (methodInfo != null)
            {
                switch (m_methods.onUpdateType)
                {
                    case Methods.ParamType.Float:
                        {
                            ltDescr.setOnUpdate(delegate(float arg)
                            {
                                object[] args = { method.target, method.param, arg };
                                methodInfo.Invoke(obj, args);
                            });
                        } break;
                    case Methods.ParamType.Vector3:
                        {
                            ltDescr.setOnUpdateVector3(delegate(Vector3 arg)
                            {
                                object[] args = { method.target, method.param, arg };
                                methodInfo.Invoke(obj, args);
                            });
                        }
                        break;
                    case Methods.ParamType.Color:
                        {
                            ltDescr.setOnUpdateColor(delegate(Color arg)
                            {
                                object[] args = { method.target, method.param, arg };
                                methodInfo.Invoke(obj, args);
                            });
                        }
                        break;
                }
            }
        }
    }

    protected static System.Reflection.MethodInfo GetMethodInfo(Method method, ref object obj)
    {
        if (method.target == null || string.IsNullOrEmpty(method.className) || string.IsNullOrEmpty(method.methodName))
            return null;
        method.className = method.className.Trim();
        method.methodName = method.methodName.Trim();
        obj = method.target.GetComponent(method.className);
        if (obj == null)
            return null;
        return obj.GetType().GetMethod(method.methodName);
    }
}
