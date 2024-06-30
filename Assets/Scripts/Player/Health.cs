using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _health;

    private float _maxHealth;

    public event Action HealthEnd;

    private void Awake()
    {
        _maxHealth = _health;
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;

        Debug.Log(_health);

        if ( _health <= 0)
        {
            HealthEnd?.Invoke();
        }
    }

    public void Reborn() => _health = _maxHealth;
}
