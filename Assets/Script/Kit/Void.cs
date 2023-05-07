using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Void : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy")||other.gameObject.CompareTag("PickUp"))
        {
            Destroy(other.gameObject);
        }
    }
}

