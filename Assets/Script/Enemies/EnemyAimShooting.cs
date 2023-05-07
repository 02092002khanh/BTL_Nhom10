using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAimShooting : MonoBehaviour
{
    [SerializeField] GameObject target, bulletPF;
    [SerializeField] float fireRate, maxRange, turnRate;
    private float rotateValue, distance;
    [SerializeField] private bool ready = true;
    private Vector3 direction;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        rb = gameObject.GetComponent<Rigidbody2D>();
         
    }

    // Update is called once per frame
    void Update()
    {        
        if(target != null)
        {
            //aimming
            direction = target.transform.position - transform.position;
            rotateValue = Vector3.Cross(transform.right, direction.normalized).z;
            rb.angularVelocity = rotateValue * turnRate;

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
            GameObject.Instantiate(bulletPF,gameObject.transform.position, transform.rotation);
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

