using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[System.Serializable]
public class LeanTweenGuiModel : LeanTweenCommModel
{
    public enum TranType
    {
        GUI_MOVE,
        GUI_MOVE_MARGIN,
        GUI_SCALE,
        GUI_ALPHA,
        GUI_ROTATE,
    }
    public TranType m_tranType;

    /// <summary>
    /// LTRect object that you wish to move
    /// </summary>
    public LTRect m_ltRect;

    /// <summary>
    /// The final position with which to move to (pixel coordinates)
    /// </summary>
    public Vector2 m_toValue;

    public override void DoAction(GameObject go)
    {
        LTDescr ltDescr = null;
        switch (m_tranType)
        {
            case TranType.GUI_MOVE:
                ltDescr = LeanTween.move(m_ltRect, m_toValue, m_time);
                break;
            case TranType.GUI_MOVE_MARGIN:
                ltDescr = LeanTween.moveMargin(m_ltRect, m_toValue, m_time);
                break;
            case TranType.GUI_SCALE:
                ltDescr = LeanTween.scale(m_ltRect, m_toValue, m_time);
                break;
            case TranType.GUI_ALPHA:
                ltDescr = LeanTween.alpha(m_ltRect, m_toValue.x, m_time);
                break;
            case TranType.GUI_ROTATE:
                ltDescr = LeanTween.rotate(m_ltRect, m_toValue.x, m_time);
                break;
        }
        
        if (ltDescr != null)
        {
            SetOptions(ltDescr);
        }
    }
}
