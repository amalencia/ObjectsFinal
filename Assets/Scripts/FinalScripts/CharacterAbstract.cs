using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterAbstract : MonoBehaviour, IDamageable, IPower
{
    public abstract void InitiateParameters();
    public abstract void Attack();
    public abstract void Move(Vector2 direction, float angle);

    public abstract void Die();

    public abstract void ReceiveDamage();

    public abstract void ReceiveDamage(int damage);

    public abstract int GetPower();
}
