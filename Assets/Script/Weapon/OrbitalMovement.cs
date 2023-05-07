using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitalMovement : MonoBehaviour
{
    
    public float speed, radius;
    // Start is called before the first frame update  
    private void Start()
    {
        transform.localPosition = transform.localPosition.normalized * radius;
    }
    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.parent.position, Vector3.forward, Time.deltaTime * speed);
        transform.Rotate(Vector3.forward, -Time.deltaTime * speed);
    }
}
