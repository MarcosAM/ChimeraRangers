using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    static InputHandler instance;

    void Awake()
    {
        if(instance != null)
        {
            instance.ClearForces();
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    bool forceFirst = false;
    bool forceSecond = false;
    bool forceThird = false;

    public void ClearForces()
    {
        forceFirst = false;
        forceSecond = false;
        forceThird = false;
    }

    public static void ForceFirst()
    {
        if(instance == null) return;
        instance.forceFirst = true;
    }

    public static void ForceSecond()
    {
        if(instance == null) return;
        instance.forceSecond = true;
    }

    public static void ForceThird()
    {
        if(instance == null) return;
        instance.forceThird = true;
    }

    public static bool GetFirstClick()
    {
        if(instance == null) return false;
        bool output = instance.forceFirst || Input.GetMouseButtonDown(0);
        if(instance.forceFirst) instance.forceFirst = false;
        return output;
    }

    public static bool GetSecondClick()
    {
        if(instance == null) return false;
        bool output = instance.forceSecond || Input.GetKeyDown("z");
        if(instance.forceSecond) instance.forceSecond = false;
        return output;
    }

    public static bool GetThirdClick()
    {
        if(instance == null) return false;
        bool output = instance.forceThird || Input.GetMouseButtonDown(1);
        if(instance.forceThird) instance.forceThird = false;
        return output;
    }

    public static bool GetFirstHold()
    {
        if(instance == null) return false;
        return Input.GetMouseButton(0);
    }

    public static bool GetSecondHold()
    {
        if(instance == null) return false;
        return Input.GetKey("z");
    }

    public static bool GetThirdHold()
    {
        if(instance == null) return false;
        return Input.GetMouseButton(1);
    }

}
