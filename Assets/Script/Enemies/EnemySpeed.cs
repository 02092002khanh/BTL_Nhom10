using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpeed : MonoBehaviour
{
    [SerializeField] float _speed;
    private Rigidbody2D _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _rb.velocity = transform.up * -_speed;
    }
}
