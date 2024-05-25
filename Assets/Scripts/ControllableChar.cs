using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllableChar 
{
    private float speed;
    private int strength;
    private Health healthPoints;

    public virtual void Attack()
    {

    }

    public virtual void Die()
    {

    }

    public virtual void Move()
    {

    }

    public ControllableChar(float speed, int health)
    {
        this.speed = speed;
        healthPoints = new Health(health);
    }
}
