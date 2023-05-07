using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoots : MonoBehaviour
{
    // chosse target type
    enum Type
    {
        Enemy,
        Player
        
    }
    [SerializeField] Type _userType;
    //self vanishing
    public float _delay;
    public int _pierceCount;    
    [SerializeField] private Rigidbody2D _rb;

    //self accelerating
    public float _speed, _accelerate;

    //dealing damage
    public int _damage;

    //visual effects
    public GameObject _hitParticle;
    private bool _hit = false;


    //sound effects
    public AudioClip _hitSound;
    // Start is called before the first frame update
    private void Start()
    {
        Destroy(gameObject, _delay);
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()  
    {
        if (!_hit)
        {
            _speed += _accelerate;
            _rb.velocity = (Vector2)transform.right * _speed;
        }
        else
        {
            _rb.velocity = Vector2.zero;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if user is the player
        if (_userType == Type.Player)
        {
            if (collision.CompareTag("Enemy"))
            {
                //vanishing           
                _pierceCount -= 1;
                if (_pierceCount == 0)
                {
                    SpriteRenderer render = gameObject.GetComponent<SpriteRenderer>();
                    Collider2D collide = gameObject.GetComponent<CircleCollider2D>();
                    render.enabled = false;
                    collide.enabled = false;
                    _rb.velocity = Vector3.zero;
                    _hit = true;
                }

                //dealing damage
                Health victim = collision.gameObject.GetComponent<Health>();
                victim.HealthChanging(-_damage);

                //play effects
                if (_hitSound != null)
                {
                    AudioSource.PlayClipAtPoint(_hitSound, transform.position);
                }
                Instantiate(_hitParticle, transform.position, Quaternion.identity);
            }
        }
        //if user is an enemy
        else if(_userType == Type.Enemy)
        {
            if (collision.CompareTag("Player") || collision.CompareTag("Ally"))
            {
                //vanishing           
                _pierceCount -= 1;
                if (_pierceCount == 0)
                {
                    SpriteRenderer render = gameObject.GetComponent<SpriteRenderer>();
                    Collider2D collide = gameObject.GetComponent<CircleCollider2D>();
                    render.enabled = false;
                    collide.enabled = false;
                    _rb.velocity = Vector3.zero;
                    _hit = true;
                }

                //dealing damage
                Health victim = collision.gameObject.GetComponent<Health>();
                victim.HealthChanging(-_damage);

                //play effects
                if (_hitSound != null)
                {
                    AudioSource.PlayClipAtPoint(_hitSound, transform.position);
                }
                Instantiate(_hitParticle, transform.position, Quaternion.identity);
            }
        }
        
    }
}
