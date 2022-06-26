using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipBlueprintUIManager : MonoBehaviour
{
    [SerializeField]
    List<Dropdown> partsDropdowns;

    void Start()
    {
        for (int idx = 0; idx < partsDropdowns.Count; idx++)
        {
            partsDropdowns[idx].value = partsDropdowns[idx].options.FindIndex(op => op.text == ShipBlueprintManager.GetShipPart(idx).ToString());
        }
    }

    void OnDropdownChange(Dropdown dropdown, int idx)
    {
        string optionTxt = dropdown.options[dropdown.value].text;
        ShipBlueprintManager.ShipParts part = ShipBlueprintManager.partsTxtDic[optionTxt];
        ShipBlueprintManager.SetParts(part, idx);
    }

    public void OnFirstDropdownChange(Dropdown dropdown)
    {
        OnDropdownChange(dropdown, 0);
    }

    public void OnSecondDropdownChange(Dropdown dropdown)
    {
        OnDropdownChange(dropdown, 1);
    }

    public void OnThirdDropdownChange(Dropdown dropdown)
    {
        OnDropdownChange(dropdown, 2);
    }

    public void OnForthDropdownChange(Dropdown dropdown)
    {
        OnDropdownChange(dropdown, 3);
    }
}
