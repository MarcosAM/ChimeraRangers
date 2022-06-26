using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DescriptionUI : MonoBehaviour
{
    [SerializeField]
    Text nameTxt;

    [SerializeField]
    Text txt;


    void OnDescriptionChanged(string partsName, string description)
    {
        nameTxt.text = partsName;
        txt.text = description;
    }

    void Start()
    {
        ShipBlueprintManager.ListenToOnDescriptionChange(OnDescriptionChanged);
    }

    void OnDestroy()
    {
        ShipBlueprintManager.CancelListenToOnDescriptionChange(OnDescriptionChanged);
    }

}
