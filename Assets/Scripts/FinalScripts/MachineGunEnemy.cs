using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunEnemy : EnemyParent
{
    public override void Attack()
    {
        _timer += Time.deltaTime;
        if (_timer > 0.2f)
        {
            _timer = 0;
            _weaponBehaviour.WeaponBehaviour(transform.position, transform.rotation, _power.CurrentPower(), "Player");
        }
    }
}
