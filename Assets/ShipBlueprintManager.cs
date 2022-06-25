using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ShipBlueprintManager : MonoBehaviour
{
    public enum ShipParts
    {
        Turbine,
        Cannon,
        Nothing
    }

    public static Dictionary<string, ShipParts> partsTxtDic = new Dictionary<string, ShipParts>()
    {
        {"Turbine", ShipParts.Turbine},
        {"Cannon", ShipParts.Cannon},
        {"Nothing", ShipParts.Nothing}
    };

    public static Dictionary<ShipParts, string[]> partsPossibleNames = new Dictionary<ShipParts, string[]>()
    {
        {ShipParts.Turbine, new string[]{"β", "γ", "δ", "ζ", "λ", "Σ", "ψ","Ω", "2000", "LV-426", "42"}},
        {ShipParts.Cannon, new string[]{"Red", "Blue", "Yellow", "Knight","Fighter","Alien","Ranger", "Maverick", "Ice", "Goose", "Man"}},
        {ShipParts.Nothing, new string[]{"Big Ballz", "God", "Casual Killer", "Alfa & Omega", "Norris"}}
    };

    static ShipBlueprintManager instance;
    List<ShipParts> parts = new List<ShipParts>() { ShipParts.Cannon, ShipParts.Cannon, ShipParts.Turbine };

    public Action<string> OnNameChanged;

    string shipsName = string.Empty;

    public static string GetName()
    {
        if (instance == null) return string.Empty;
        return instance.shipsName;
    }

    public static void ListenToOnNameChange(Action<string> callback)
    {
        if (instance == null) return;
        instance.OnNameChanged += callback;
    }

    public static void CancelListenToOnNameChange(Action<string> callback)
    {
        if (instance == null) return;
        instance.OnNameChanged -= callback;
    }

    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
        shipsName = GetNameFromParts(parts);
    }

    static string GetNameFromPart(ShipParts part)
    {
        string[] possibles = partsPossibleNames[part];
        return possibles[UnityEngine.Random.Range(0, possibles.Length)];
    }

    static string GetNameFromParts(List<ShipParts> parts)
    {
        string[] names = parts.ConvertAll<string>(part => GetNameFromPart(part)).ToArray();
        if (names.Length == 3)
            return string.Format("{0} {1} {2}", names[0], names[1], names[2]);
        return string.Empty;
    }

    public static void SetParts(ShipParts part, int idx)
    {
        if (instance != null)
        {
            if (idx >= 0 && idx < instance.parts.Count)
            {
                instance.parts[idx] = part;
                instance.shipsName = GetNameFromParts(instance.parts);
                if (instance.OnNameChanged != null) instance.OnNameChanged(instance.shipsName);
            }
        }
    }

    public static ShipParts GetShipPart(int idx)
    {
        if (instance != null)
        {
            if (idx >= 0 && idx < instance.parts.Count)
            {
                return instance.parts[idx];
            }
        }
        return ShipParts.Nothing;
    }
}
