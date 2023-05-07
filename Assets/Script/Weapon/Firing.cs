using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firing : MonoBehaviour
{
    public int currentLever = 1;
    [SerializeField] GameObject _bullet;
    [SerializeField] float _bulletSpeed, _bulletCount, _coneAngle, _fireRate;
    bool _ready = true;
    Transform _trans;
    public AudioClip _firingAudio;


    private void Start()
    {
        _trans = gameObject.transform;

    }
    void FixedUpdate()
    {
        if ( _ready)
        {
            Fire();
        }
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(1 / _fireRate);
        _ready = true;
    }

    //fire 
    private void Fire()
    {
        _ready = false;
        for (int i = 0; i < _bulletCount; i++)
        {
            //random angle
            float _shootAngle = Random.Range(-_coneAngle, _coneAngle);
            Vector3 _shootVector = new Vector3(0, 0, _shootAngle);
            //spawn bullets
            GameObject _firedBullet;
            _firedBullet = Instantiate(_bullet, _trans.position, _trans.rotation);

            //rotate the bullet;
            
            Transform bulletTrans;
            bulletTrans = _firedBullet.GetComponent<Transform>();
            bulletTrans.eulerAngles = bulletTrans.eulerAngles + _shootVector;
        }

        //play the sound effect
        if (_firingAudio != null)
        {
            AudioSource.PlayClipAtPoint(_firingAudio, transform.position);
        }

        //reloading
        StartCoroutine(Reload());
    }
     public void LeverUp()
     {
        switch (currentLever)
        {
            case 1: _bulletCount += 2; break;
            case 2: _fireRate *= 1.5f; break;
            case 3: _bulletCount += 2; break;
            case 4: _fireRate *= 1.5f; break;
            case 5: _bulletCount += 2; break;
        }
        currentLever ++;
     }
}

