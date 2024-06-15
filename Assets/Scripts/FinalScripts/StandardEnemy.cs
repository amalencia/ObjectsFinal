using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class StandardEnemy : EnemyParent
{
    protected override void SetDifficulty()
    {
        base.SetDifficulty();
        if (GameManager.singleton.GetGameLevel() > 1)
        {
            int number = GameManager.singleton.GetGameLevel() - 1;
            for(int i = 0; i < number; i++)
            {
                _health.IncreaseMaxHealth(25);
                _armor.IncreaseMaxArmor(25);
            }
        }
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
