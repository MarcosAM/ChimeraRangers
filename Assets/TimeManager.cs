using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeManager : MonoBehaviour
{
    bool running = true;
    float time = 0;

    public Action<float> OnTimeChange;

    float Time
    {
        get
        {
            return time;
        }
        set
        {
            time = value;
            if (OnTimeChange != null) OnTimeChange(time);
        }
    }

    float intervals = 1f;

    IEnumerator Timer()
    {
        while (running)
        {
            yield return new WaitForSeconds(intervals);
            Time += intervals;
        }
    }

    void Play()
    {
        running = true;
        StartCoroutine("Timer");
    }

    public void Stop()
    {
        running = false;
        StopAllCoroutines();
    }

    void Start()
    {
        Play();
    }

    public float GetTime() { return time; }
}
