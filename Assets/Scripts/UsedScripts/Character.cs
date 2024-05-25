using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public abstract void InitiateParams();
    public abstract void Attack();
    public abstract void Move();
    public abstract void Die();


}
