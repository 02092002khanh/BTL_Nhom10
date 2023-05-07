using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairPickUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Health>().HealthChanging(60);
            Destroy(gameObject);
        }
    }
}
