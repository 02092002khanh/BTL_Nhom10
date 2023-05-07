using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBackGround : MonoBehaviour
{
    private void Update() 
    {
        transform.position -= new Vector3(0, 2 * Time.deltaTime);
        if (transform.position.y < -43f)
        {
            transform.position = new Vector3(transform.position.x, 43f);
        }
    } 
}