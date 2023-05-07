using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePickUp : MonoBehaviour
{
    WeaponHolder wh;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            wh = collision.gameObject.GetComponentInChildren<WeaponHolder>();
            if(wh != null)
            {
                wh.LeverChange();
                Destroy(gameObject);
            }              
        }
    }
}
