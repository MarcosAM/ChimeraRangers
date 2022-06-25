using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipBlueprintUIManager : MonoBehaviour
{
    public void OnDropdownChange(Dropdown dropdown)
    {
        string optionTxt = dropdown.options[dropdown.value].text;
        ShipBlueprintManager.ShipParts part = ShipBlueprintManager.partsTxtDic[optionTxt];
        ShipBlueprintManager.SetParts(part, 0);
    }
}
