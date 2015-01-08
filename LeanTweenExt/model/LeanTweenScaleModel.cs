using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[System.Serializable]
public class LeanTweenScaleModel : LeanTweenCommTranModel
{
    public override void DoAction(GameObject go)
    {
        LTDescr ltDescr = null;
        switch (m_target.type)
        {
            case AxisType.Axis_X:
                ltDescr = LeanTween.scaleX(go, m_target.x, m_time);
                break;
            case AxisType.Axis_Y:
                ltDescr = LeanTween.scaleY(go, m_target.y, m_time);
                break;
            case AxisType.Axis_Z:
                ltDescr = LeanTween.scaleZ(go, m_target.z, m_time);
                break;
            case AxisType.Axis_A:
                if (m_target.values.Length > 0)
                    ltDescr = LeanTween.scale(go, m_target.values[0], m_time);
                break;
        }

        if (ltDescr != null)
        {
            SetOptions(ltDescr);
        }
    }
}
