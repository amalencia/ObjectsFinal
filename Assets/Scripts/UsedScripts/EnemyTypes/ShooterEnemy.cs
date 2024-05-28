using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemy : EnemyParent
{
    public override void Attack()
    {
        _timer += Time.deltaTime;
        Debug.Log("timer is " +  _timer);
        if (_timer > 3f)
        {
            
            _weaponBehaviour.WeaponBehaviour(transform.position, transform.rotation, _power.CurrentPower(), "Player");

            _timer = 0;
        }
    }
}
