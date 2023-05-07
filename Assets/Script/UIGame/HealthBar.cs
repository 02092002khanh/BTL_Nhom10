using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private float currentHealth, Maxhealth;
    Health playerHealth;
    Slider _healthBar;

    private void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        _healthBar = gameObject.GetComponent<Slider>();
    }

    private void Update()
    {
        currentHealth = playerHealth.currentHealth;
        Maxhealth = playerHealth.maxHealth;
        _healthBar.value = currentHealth / Maxhealth;
    }
}
