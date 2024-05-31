using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Health", menuName = "Health Class")]
public class Health : ScriptableObject
{
    [SerializeField] private int _maxHealth;
    private int _currentHealth;

    public int GetCurrentHealth()
    {
        return _currentHealth;
    }

    public void InitializeHealth()
    {
        _currentHealth = _maxHealth;
    }

    public int GetMaxHealth()
    {
        return _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        if (_currentHealth < 0)
        {
            _currentHealth = 0;
        }
    }

    public void Repair(int heal)
    {
        _currentHealth += heal;
        if(_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
    }

    public void IncreaseMaxHealth(int maxIncrease)
    {
        _maxHealth += maxIncrease;
    }
}
