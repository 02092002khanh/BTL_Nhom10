using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] GameObject target, bulletPF;
    [SerializeField] float fireRate, bulletCount, maxRange, _angle;
    private float rotateValue, distance;
    [SerializeField] private bool ready = true;
    private Vector3 direction;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        rb = gameObject.GetComponent<Rigidbody2D>();
        //create fire points
        float offset = (bulletCount/2 - 0.5f)*_angle;
        for(int i = 0; i<bulletCount; i++)
        {
            GameObject firepoint = new GameObject("firepoint" + i.ToString());
            firepoint.transform.parent = gameObject.transform;
            firepoint.transform.position = gameObject.transform.position;
            firepoint.transform.localEulerAngles = new Vector3(0, 0, -offset+i*_angle + 90);
        }
        
    }

    // Update is called once per frame
    void Update()
    {        
        if(target != null)
        {
            //cling on parent
            gameObject.transform.position = transform.parent.transform.position;

            //shooting
            distance = ((Vector2)(target.transform.position - transform.position)).magnitude;
            if (distance < maxRange)
            {
                Fire();
            }
        }
    }
    private void Fire()
    {               
        if (ready)
        {
            foreach(Transform child in transform)
            {
                GameObject.Instantiate(bulletPF,child.position, child.rotation);
                
            }
            ready = false;          
            StartCoroutine(Reload());
        }       
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(1 / fireRate);
        ready = true;
    }
}

