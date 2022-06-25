using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ScoreTxtUI : MonoBehaviour
{
    [SerializeField]
    Text text;

    void Start()
    {
        TimeSpan ts = TimeSpan.FromSeconds(ScoreManager.GetTime());
        text.text = string.Format("Your Time: {0}:{1}", ts.Minutes, ts.Seconds);
    }
}
