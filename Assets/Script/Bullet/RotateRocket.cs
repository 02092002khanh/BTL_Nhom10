using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRocket : MonoBehaviour
{
    [SerializeField] GameObject[] _enemy;
    public GameObject _closetEnemy;
    float _distansce = Mathf.Infinity , _rotateValue, _additonalTurnRate;
    [SerializeField] float _turnRate;
    Vector3 _currentDistance, _direction;
    Rigidbody2D _rb;
    Shoots _shoots;
    private void Start()
    {
        _shoots = gameObject.GetComponent<Shoots>();
        _rb = gameObject.GetComponent<Rigidbody2D>();
        Caculate();
    }   

    // Update is called once per frame
    private void Caculate()
    {
        _distansce = Mathf.Infinity;
        _enemy = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject target in _enemy)
        {
            _currentDistance = target.transform.position - transform.position;
            if (_currentDistance.sqrMagnitude < _distansce)
            {
                _closetEnemy = target;
                _distansce = _currentDistance.sqrMagnitude;
            }
        }   
    }
    private void FixedUpdate()
    {   
        if(_closetEnemy != null)
        {
            _direction = _closetEnemy.transform.position - transform.position;
            _rotateValue = Vector3.Cross(transform.right, _direction.normalized).z;
            _additonalTurnRate += 3f;
            _rb.angularVelocity = _rotateValue * (_turnRate + _additonalTurnRate);
        }    
        else
        {
            Caculate();
        }
    }
}
