using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[System.Serializable]
public class LeanTweenCanvasModel : LeanTweenCommModel
{
    public enum TranType
    {
        CANVAS_MOVE,
        CANVAS_SCALE,
        CANVAS_ALPHA,
        CANVAS_ROTATEAROUND,
        CANVAS_COLOR,
    }
    public TranType m_tranType;

    /// <summary>
    /// RectTransform that you wish to attach the tween to
    /// </summary>
    public RectTransform m_rectTran;

    /// <summary>
    /// The final value with which to transform to.
    /// </summary>
    public Vector4 m_toValue;
    public Color m_toColor;

    public override void DoAction(GameObject go)
    {
        LTDescr ltDescr = null;
        switch (m_tranType)
        {
            case TranType.CANVAS_MOVE:
                ltDescr = LeanTween.move(m_rectTran, new Vector3(m_toValue.x, m_toValue.y, m_toValue.z), m_time);
                break;
            case TranType.CANVAS_SCALE:
                ltDescr = LeanTween.scale(m_rectTran, new Vector3(m_toValue.x, m_toValue.y, m_toValue.z), m_time);
                break;
            case TranType.CANVAS_ALPHA:
                ltDescr = LeanTween.alpha(m_rectTran, m_toValue.x, m_time);
                break;
            case TranType.CANVAS_ROTATEAROUND:
                ltDescr = LeanTween.rotate(m_rectTran, m_toValue.x, m_time);
                break;
            case TranType.CANVAS_COLOR:
                ltDescr = LeanTween.color(m_rectTran, m_toColor, m_time);
                break;
        }

        if (ltDescr != null)
        {
            SetOptions(ltDescr);
        }
    }
}
