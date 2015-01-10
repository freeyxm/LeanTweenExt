using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[System.Serializable]
public class LeanTweenCommTranModel : LeanTweenCommModel
{
    public enum AxisType
    {
        Axis_A = 0x00,
        Axis_X = 0x01,
        Axis_Y = 0x02,
        Axis_Z = 0x04,
        Axis_XY = 0x80 | Axis_X | Axis_Y,
    }

    [System.Serializable]
    public struct Target
    {
        /// <summary>
        /// deside which field will be use: values, x, y, z.
        /// </summary>
        public AxisType type;

        /// <summary>
        /// for the final values.
        /// </summary>
        public Vector3[] values;

        /// <summary>
        /// for the individual setting of the x axis.
        /// </summary>
        public float x;
        /// <summary>
        /// for the individual setting of the y axis.
        /// </summary>
        public float y;
        /// <summary>
        /// for the individual setting of the z axis.
        /// </summary>
        public float z;
    };
    public Target m_target;

    [System.Serializable]
    public class From
    {
        public bool enable = false;
        public Vector3 from;
    }
    public From m_from;

    protected virtual void SetOptions(LTDescr ltDescr)
    {
        base.SetOptions(ltDescr);
        if (m_from.enable)
            ltDescr.setFrom(m_from.from);
    }
}
