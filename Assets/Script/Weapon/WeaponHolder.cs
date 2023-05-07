using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField] GameObject[] weapons;
    [SerializeField] int choosenWeaponIndex;
    // Start is called before the first frame update
    void Start()
    {
        int i = 0;
        foreach (Transform child in transform)
        {
            weapons[i] = child.gameObject;
            i++;
        }
        i = 0;
        
    }

    // Update is called once per frame   
    public void LeverChange()
    {
        //choose the weaponds
        int weaponsIndex = ChooseWeapond();
        Debug.Log(weaponsIndex);
        //upgrade the choosen weapond
        UpgradeComponent upgradeComponent = weapons[weaponsIndex].GetComponent<UpgradeComponent>();
        upgradeComponent.Upgrade();
    }

    public int ChooseWeapond()
    {
        choosenWeaponIndex ++;
        choosenWeaponIndex = choosenWeaponIndex % weapons.Length;
        return choosenWeaponIndex;        
    }
}
