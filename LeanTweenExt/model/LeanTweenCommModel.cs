using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[System.Serializable]
public class LeanTweenCommModel
{
    [System.Serializable]
    public struct MethodInfo
    {
        GameObject target;
        public string name;
        public string param;
    }

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
}
