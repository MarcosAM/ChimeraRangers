using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipNameUI : MonoBehaviour
{

    [SerializeField]
    Text text;

    void OnNameChanged(string name)
    {
        text.text = string.Format("Name: {0}", name);
    }

    void Start()
    {
        OnNameChanged(ShipBlueprintManager.GetName());
        ShipBlueprintManager.ListenToOnNameChange(OnNameChanged);
    }

    void OnDestroy()
    {
        ShipBlueprintManager.CancelListenToOnNameChange(OnNameChanged);
    }
}
