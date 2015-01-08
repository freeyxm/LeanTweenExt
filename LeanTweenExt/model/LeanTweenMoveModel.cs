using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[System.Serializable]
public class LeanTweenMoveModel : LeanTweenCommTranModel
{
    /// <summary>
    /// whether in local space.
    /// </summary>
    public bool m_isLocal = false;

    /// <summary>
    /// use spline mode. (Only available when m_target.values.Length > 1)
    /// </summary>
    public bool m_isSpline = false;

    public override void DoAction(GameObject go)
    {
        LTDescr ltDescr = null;
        switch (m_target.type)
        {
            case AxisType.Axis_X:
                if (m_isLocal)
                    ltDescr = LeanTween.moveLocalX(go, m_target.x, m_time);
                else
                    ltDescr = LeanTween.moveX(go, m_target.x, m_time);
                break;
            case AxisType.Axis_Y:
                if (m_isLocal)
                    ltDescr = LeanTween.moveLocalY(go, m_target.y, m_time);
                else
                    ltDescr = LeanTween.moveY(go, m_target.y, m_time);
                break;
            case AxisType.Axis_Z:
                if (m_isLocal)
                    ltDescr = LeanTween.moveLocalZ(go, m_target.z, m_time);
                else
                    ltDescr = LeanTween.moveZ(go, m_target.z, m_time);
                break;
            case AxisType.Axis_XY:
                ltDescr = LeanTween.move(go, new Vector2(m_target.x, m_target.y), m_time);
                break;
            case AxisType.Axis_A:
                if (m_target.values.Length == 1)
                {
                    if (m_isLocal)
                        ltDescr = LeanTween.moveLocal(go, m_target.values[0], m_time);
                    else
                        ltDescr = LeanTween.move(go, m_target.values[0], m_time);
                }
                else if (m_target.values.Length > 1)
                {
                    if (m_isSpline)
                    {
                        if (m_isLocal)
                            ltDescr = LeanTween.moveSplineLocal(go, m_target.values, m_time);
                        else
                            ltDescr = LeanTween.moveSpline(go, m_target.values, m_time);
                    }
                    else
                    {
                        if (m_isLocal)
                            ltDescr = LeanTween.moveLocal(go, m_target.values, m_time);
                        else
                            ltDescr = LeanTween.move(go, m_target.values, m_time);
                    }
                }
                break;
        }

        if (ltDescr != null)
        {
            SetOptions(ltDescr);
        }
    }
}
