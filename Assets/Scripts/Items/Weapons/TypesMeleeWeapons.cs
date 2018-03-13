using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypesMeleeWeapons : MonoBehaviour {

    public float weaponDurability;
    public float weaponWeight;
    public string weaponName;
    public string weaponType;
    public string flavourText;

    //********************TYPE DAGGERS**********************\\

    public void RustyKnife()
    {
        weaponType = "Dagger";
        weaponName = "RustyKnife";
        weaponWeight = .3f;
        weaponDurability = .1f;
        flavourText = "";
    }

    public void WoodenSpoon()
    {
        weaponType = "Dagger";
        weaponName = "WoodenSpoon";
        weaponWeight = .8f;
        weaponDurability = 1f;
        flavourText = "";
    }

    //********************TYPE DUELING**********************\\

    //********************TYPE SWORDS**********************\\

    //********************TYPE CLEAVERS**********************\\
}
