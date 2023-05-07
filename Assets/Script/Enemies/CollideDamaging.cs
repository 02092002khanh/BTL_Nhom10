using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideDamaging : MonoBehaviour
{
    enum Targets
    {
        Player,
        Enemy
    }
    [SerializeField] Targets targetType;
    [SerializeField] int damage;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag(targetType.ToString()))
        {
            Health targetHealth = other.gameObject.GetComponent<Health>();
            targetHealth.HealthChanging(-damage);

            if (gameObject.CompareTag("Enemy")) ;
            {
                Destroy(gameObject);
            }
        }
        
    }
}
