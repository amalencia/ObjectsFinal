using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPractice : CharacterPractice, IWeapon
{
    public EnemyPractice(int health, string name) : base(health, name)
    {
        _health = health;
        _name = name;
    }

    public override void Move()
    {
        base.Move();
    }

    public void Attack()
    {

    }
}
