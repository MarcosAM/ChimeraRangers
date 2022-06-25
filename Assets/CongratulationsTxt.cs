using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CongratulationsTxt : MonoBehaviour
{
    [SerializeField]
    Text text;

    void Start()
    {
        text.text = string.Format("CONGRATULATIONS {0}", ShipBlueprintManager.GetName());
    }
}
