using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TimerUI : MonoBehaviour
{
    [SerializeField]
    Text text;
    [SerializeField]
    TimeManager timeManager;

    void SetTimerTxt(float time)
    {
        TimeSpan ts = TimeSpan.FromSeconds(time);
        text.text = string.Format("{0}:{1}", ts.Minutes, ts.Seconds);
    }

    void Start()
    {
        if (timeManager != null && text != null)
        {
            SetTimerTxt(timeManager.GetTime());
            timeManager.OnTimeChange += SetTimerTxt;
        }
    }
}
