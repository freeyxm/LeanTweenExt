using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[System.Serializable]
public class LeanTweenColorModel : LeanTweenCommModel
{
    [System.Serializable]
    public class FromColor
    {
        public bool enable = false;
        public Color from;
    }
    public FromColor m_fromColor; // Is useful or not ???

    /// <summary>
    /// the final color value ex: Color.Red, new Color(1.0f,1.0f,0.0f,0.8f)
    /// </summary>
    public Color m_color;

    protected virtual void SetOptions(LTDescr ltDescr)
    {
        base.SetOptions(ltDescr);
        if (m_fromColor.enable)
            ltDescr.setFromColor(m_fromColor.from);
    }

    public override void DoAction(GameObject go)
    {
        LTDescr ltDescr = LeanTween.color(go, m_color, m_time);
        if (ltDescr != null)
        {
            SetOptions(ltDescr);
        }
    }
}
