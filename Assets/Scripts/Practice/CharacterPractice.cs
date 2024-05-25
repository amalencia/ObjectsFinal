using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPractice
{
    protected int _health;
    protected string _name;

    public virtual void Move()
    {

    }

    private void Attack()
    {

    }

    public void Eat()
    {

    }

    public CharacterPractice(int health, string name)
    {
        _health = health;
        _name = name;
    }
}
