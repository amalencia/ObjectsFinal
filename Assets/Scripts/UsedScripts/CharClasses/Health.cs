using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Health
{
    private int _maxHealth;
    private int _currentHealth;

    public int MaxHealth
    {
        get
        {
            return _maxHealth;
        }
    }

    public int GetCurrentHealth()
    {
        return _currentHealth;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        Debug.Log("Lost health, health now: " + _currentHealth);
    }

    public void TakeDamage()
    {
        _currentHealth--;
        Debug.Log("Lost health, health now: " +  _currentHealth);
    }

    public void Repair()
    {
        _currentHealth++;
        if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
    }

    public void Repair(int heal)
    {
        if((_currentHealth + heal) > _maxHealth)
        {
            _currentHealth = _maxHealth;
        } else
        {
            _currentHealth += heal;
        }
    }

    public Health(int maxHealth)
    {
        _maxHealth = maxHealth;
        _currentHealth = maxHealth;
    }
}
