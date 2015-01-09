﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class LeanTweenRotate : LeanTweenBase
{
    public LeanTweenRotateModel[] m_actions = new LeanTweenRotateModel[1];

    public override bool StartLeanTweenAction(string name)
    {
        bool flag = base.StartLeanTweenAction(name);
        if (flag)
        {
            for (int i = 0; i < m_actions.Length; ++i)
            {
                m_actions[i].DoAction(this.gameObject);
            }
        }
        return flag;
    }

    void OnEnable()
    {
        StartLeanTweenAction("");
    }
}
