using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] Vector3 _mousePos;
    private Vector3 _rayCast, _offSet = new Vector3 (0f,0f,10f);
    [SerializeField] float _speed, _distance;
    // Start is called before the first frame update
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _mousePos = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition) + _offSet;
        _rayCast = _mousePos - transform.position;

        _distance = ((Vector2)_rayCast).magnitude;

        if (_distance > 0.1f)
        {           
            _rb.velocity = _rayCast.normalized * _speed;
        }
        else
        {
            _rb.velocity = Vector2.zero;
        }
    }
        
        // --------Movement with touch -------------
        // if(Input.touchCount > 0)
        // {
        //     Touch _touch = Input.GetTouch(0);
        //     _touchPosition = Camera.main.ScreenToWorldPoint(_touchPosition);
        //     _touchPosition.z = 0;
        //     _direction = (_touchPosition - transform.position);
        //     _rb.velocity = new Vector2(_direction.x, _direction.y) * _speed;

        //     if(_touch.phase == TouchPhase.Ended)
        //     {
        //         _rb.velocity = Vector2.zero;
        //     }

        // }     
}
