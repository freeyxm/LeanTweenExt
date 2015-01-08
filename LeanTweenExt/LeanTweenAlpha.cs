﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class LeanTweenAlpha : LeanTweenBase
{
    public LeanTweenAlphaModel[] m_actions = new LeanTweenAlphaModel[1];

    public override bool StartITweenAction(string name)
    {
        bool flag = base.StartITweenAction(name);
        if (flag)
        {
            for (int i = 0; i < m_actions.Length; ++i)
            {
                m_actions[i].DoAction(this.gameObject);
            }
        }
        return flag;
    }
}
