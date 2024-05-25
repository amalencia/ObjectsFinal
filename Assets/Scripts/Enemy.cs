using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy 
{
    private Health _healthPoints;
    private float _baseSpeed;
    private int _armor;
    public Enemy(float speed, int health, int armor)
    {
        speed = _baseSpeed;
        _healthPoints = new Health(health);
        _armor = armor;
    }

    public virtual void Attack()
    {

    }

    private void Die()
    {

    }

    private void Move()
    {

    }
}
