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
        TripleCannon,
        Commander,
        Brake,
        Stabilizer,
        Nothing
    }

    public static Dictionary<string, ShipParts> partsTxtDic = new Dictionary<string, ShipParts>()
    {
        {"Turbine", ShipParts.Turbine},
        {"Cannon", ShipParts.Cannon},
        {"TripleCannon", ShipParts.TripleCannon},
        {"Commander", ShipParts.Commander},
        {"Brake", ShipParts.Brake},
        {"Stabilizer", ShipParts.Stabilizer},
        {"Nothing", ShipParts.Nothing}
    };

    public static Dictionary<ShipParts, string[]> partsPossibleNames = new Dictionary<ShipParts, string[]>()
    {
        {ShipParts.Turbine, new string[]{"β", "γ", "δ", "ζ", "λ", "Σ", "ψ","Ω", "2000", "LV-426", "42"}},
        {ShipParts.Cannon, new string[]{"Red", "Blue", "Yellow", "Knight","Fighter","Alien","Ranger", "Maverick", "Ice", "Goose", "Man"}},
        {ShipParts.TripleCannon, new string[]{"Mad", "MadDog", "Shotgun", "Hydra","Twins","Tripple","Danger", "Hunter", "Tri-Headed"}},
        {ShipParts.Commander, new string[]{"Commander", "Lord", "King", "Queen", "Zeus", "Odin"}},
        {ShipParts.Brake, new string[]{"Static", "Elder", "Ground", "Patriot", "Stand"}},
        {ShipParts.Stabilizer, new string[]{"Focus", "Zen", "Lotus", "White", "Rock", "Stoic"}},
        {ShipParts.Nothing, new string[]{"Big Ballz", "God", "Casual Killer", "Alfa & Omega", "Norris"}}
    };

    public static Dictionary<ShipParts, string> partsDescriptions = new Dictionary<ShipParts, string>()
    {
        {ShipParts.Turbine, "Push the ship in the direction of the mouse. (Active)"},
        {ShipParts.Cannon, "Fires a projectile in the direction of the mouse. (Active)"},
        {ShipParts.TripleCannon, "Fires three short-range projectiles in the direction of the mouse. (Active)"},
        {ShipParts.Commander, "Fire with all weapons at the same time. (Active)"},
        {ShipParts.Brake, "Immediately and completely stops the ship. (Active)"},
        {ShipParts.Stabilizer, "Reduce weapon recoil. (Passive)"},
        {ShipParts.Nothing, "Nothing, because you don't need help."}
    };

    static ShipBlueprintManager instance;
    List<ShipParts> parts = new List<ShipParts>() { ShipParts.Commander, ShipParts.Cannon, ShipParts.Cannon, ShipParts.Turbine };

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

    public Action<string, string> OnDescriptionChanged;

    public static void ListenToOnDescriptionChange(Action<string, string> callback)
    {
        if (instance == null) return;
        instance.OnDescriptionChanged += callback;
    }

    public static void CancelListenToOnDescriptionChange(Action<string, string> callback)
    {
        if (instance == null) return;
        instance.OnDescriptionChanged -= callback;
    }

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
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
        if (names.Length == 4)
            return string.Format("{0} {1} {2} {3}", names[0], names[1], names[2], names[3]);
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
                if (instance.OnDescriptionChanged != null) instance.OnDescriptionChanged(part.ToString(), partsDescriptions[part]);
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
