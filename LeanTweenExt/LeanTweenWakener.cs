using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class LeanTweenWakener : MonoBehaviour
{
    [System.Serializable]
    public struct ActionInfo
    {
        public GameObject target;
        public string name;
        public float delay;
        public bool broadcast;
    }
    public ActionInfo[] actions;

    void OnEnable()
    {
        for (int i = 0; i < actions.Length; ++i)
        {
            ActionInfo action = actions[i];
            if (action.delay <= 0)
            {
                StartAction(action);
            }
            else
            {
                LeanTween.delayedCall(action.delay, delegate() {
                    StartAction(action);
                });
            }
        }
    }

    void StartAction(ActionInfo action)
    {
        if (action.broadcast)
            action.target.BroadcastMessage("StartLeanTweenAction", action.name, SendMessageOptions.DontRequireReceiver);
        else
            action.target.SendMessage("StartLeanTweenAction", action.name, SendMessageOptions.DontRequireReceiver);
    }
}
