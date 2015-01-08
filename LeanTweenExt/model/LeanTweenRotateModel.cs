using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[System.Serializable]
public class LeanTweenRotateModel : LeanTweenCommTranModel
{
    /// <summary>
    /// whether in local space.
    /// </summary>
    public bool m_isLocal = false;

    /// <summary>
    /// rotate around a certain Axis
    /// </summary>
    public bool m_isAroundAxis = false;

    /// <summary>
    /// the degrees in which to rotate.
    /// </summary>
    public float m_aroundDegree;

    public override void DoAction(GameObject go)
    {
        LTDescr ltDescr = null;
        switch (m_target.type)
        {
            case AxisType.Axis_X:
                ltDescr = LeanTween.rotateX(go, m_target.x, m_time);
                break;
            case AxisType.Axis_Y:
                ltDescr = LeanTween.rotateY(go, m_target.y, m_time);
                break;
            case AxisType.Axis_Z:
                ltDescr = LeanTween.rotateZ(go, m_target.z, m_time);
                break;
            case AxisType.Axis_A:
                if (m_target.values.Length == 0)
                    break;
                if (m_isAroundAxis)
                {
                    if (m_isLocal)
                        ltDescr = LeanTween.rotateAroundLocal(go, m_target.values[0], m_aroundDegree, m_time);
                    else
                        ltDescr = LeanTween.rotateAround(go, m_target.values[0], m_aroundDegree, m_time);
                }
                else
                {
                    if (m_isLocal)
                        ltDescr = LeanTween.rotateLocal(go, m_target.values[0], m_time);
                    else
                        ltDescr = LeanTween.rotate(go, m_target.values[0], m_time);
                }
                break;
        }

        if (ltDescr != null)
        {
            SetOptions(ltDescr);
        }
    }
}
