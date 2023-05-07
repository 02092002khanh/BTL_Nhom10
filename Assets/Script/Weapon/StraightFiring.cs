using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightFiring : MonoBehaviour
{
    enum Type
    {
        Rifle,
        Laser
    }
    [SerializeField] Type type;
    public int currentLever = 1;
    [SerializeField] GameObject bullet;
    [SerializeField] float bulletCount, fireRate, width, height;
    [SerializeField] List<GameObject> firePoints;   
    bool ready = true;
    Transform trans;
    public AudioClip firingAudio;


    private void Start()
    {     
        ReArranged();
               
    }
    void FixedUpdate()
    {
        if (ready)
        {
            Fire();
        }
        
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(1 / fireRate);
        ready = true;
    }

    //fire 
    private void Fire()
    {
        ready = false;
        foreach(GameObject firePoint in firePoints)
        {
            if(firePoint != null)
            {
                GameObject.Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
            }
            
        }

        //play the sound effect
        if (firingAudio != null)
        {
            AudioSource.PlayClipAtPoint(firingAudio, transform.position);
        }

        //reloading
        StartCoroutine(Reload());
    }

    public void LeverUp()
    {
        if(type == Type.Rifle)
        {
            switch (currentLever)
            {
                case 1: bulletCount += 2;ReArranged(); break;
                case 2: fireRate += 1; break;
                case 3: bulletCount += 2;ReArranged(); break;
                case 4: fireRate += 1; break;
                case 5: fireRate += 1; break;
            }
        }
        else if(type == Type.Laser)
        {
            switch (currentLever)
            {
                case 1: bulletCount += 1;ReArranged(); break;
                case 2: fireRate *= 1.5f; break;
                case 3: fireRate *= 1.5f; break;
                case 4: fireRate *= 1.5f; break;
                case 5: bulletCount += 1;ReArranged(); break;
            }
        }
        currentLever ++;
    }

    private void ReArranged()
    {
        bulletCount = Mathf.Clamp(bulletCount,0,6);
        //delete current fire point;
        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        firePoints.Clear();
        //create fire points
        float offset = (bulletCount / 2 - 0.5f) * width;
        for(int i = 0; i<bulletCount; i++)
        {
            GameObject firepoint = new GameObject("firepoint" + i.ToString());
            firepoint.transform.parent = gameObject.transform;
            //arrangement
            float offsetX, offsetY;
            offsetX = -offset + i * width;
            offsetY = Mathf.Abs((bulletCount-1) / 2 - Mathf.Abs(i - (bulletCount-1) / 2)) * height;           
            firepoint.transform.localPosition = new Vector3(offsetX, offsetY, 0);
            firepoint.transform.localEulerAngles = new Vector3(0, 0, 90);
            firePoints.Add(firepoint);
        }
        // //gather all fire points
        // int j = 0;  
        // Debug.Log(j); 
        // foreach (Transform child in transform)
        // {           
        //     firePoints[j] = child.gameObject;
        //     j++;
        // }       
    }
}