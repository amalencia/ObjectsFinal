using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class StandardEnemy : EnemyParent
{
    protected void Update()
    {

    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

    }

    public override void Move(Vector2 direction, float angle)
    {
        base.Move(direction, angle);
    }
    public override void Attack()
    {
        _timer += Time.deltaTime;
        if(_timer > 1f)
        {
            _timer = 0;
            _weaponBehaviour.WeaponBehaviour(transform.position, transform.rotation, _power.CurrentPower(), "Player");
        }
    }
}
