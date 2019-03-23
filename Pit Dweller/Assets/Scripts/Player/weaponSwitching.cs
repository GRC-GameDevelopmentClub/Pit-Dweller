using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponSwitching : MonoBehaviour {
    public int weaponPos;
	
	void Start () {
        WeaponSwitch();
	}
	
	
	void Update () {
        int previousWeapon = weaponPos;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (weaponPos >= transform.childCount - 1)
            {
                weaponPos = 0;
            }
            else
            {
                weaponPos++;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (weaponPos <= 0)
            {
                weaponPos = transform.childCount -1;
            }
            else
            {
                weaponPos--;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weaponPos = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            weaponPos = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            weaponPos = 2;
        }

        if (previousWeapon != weaponPos)
        {
            WeaponSwitch();
        }
    }

    public void WeaponSwitch()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == weaponPos)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
