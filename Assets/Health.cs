using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Health : MonoBehaviour
{
    [SerializeField] int _startHealth;
    [SerializeField] int _maxHealth;

    public event UnityAction OnDamage;
    public event UnityAction OnDie;

    public int CurrentHealth { get; private set; }

    public bool IsDead => CurrentHealth <= 0;

    private void Start()
    {
        CurrentHealth = _startHealth;   
    }

    internal void Damage()
    {
        CurrentHealth--;    // TMP
        OnDamage?.Invoke();
    }

}
