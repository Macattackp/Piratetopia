using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    Unarmed,
    Melee,
    Ranged
}

public class WeaponUse : MonoBehaviour {

    public WeaponType weaponType = WeaponType.Unarmed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void WeaponSwitch()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            weaponType = WeaponType.Unarmed;
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            weaponType = WeaponType.Melee;
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            weaponType = WeaponType.Ranged;
        }
    }
}
