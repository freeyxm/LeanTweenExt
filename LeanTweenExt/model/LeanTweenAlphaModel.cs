using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[System.Serializable]
public class LeanTweenAlphaModel : LeanTweenCommModel
{
    /// <summary>
    /// the final alpha value (0-1)
    /// </summary>
    public float m_alpha;

    public override void DoAction(GameObject go)
    {
        LTDescr ltDescr = LeanTween.alpha(go, m_alpha, m_time);
        if (ltDescr != null)
        {
            SetOptions(ltDescr);
        }
    }
}
