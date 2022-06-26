using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    static ScoreManager instance;

    float time;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public static void SetTime(float time)
    {
        if (instance != null)
        {
            instance.time = time;
        }
    }

    public static float GetTime()
    {
        if (instance == null) return 0;
        return instance.time;
    }
}
