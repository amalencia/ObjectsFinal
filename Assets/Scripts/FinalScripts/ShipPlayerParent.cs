using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.Events;

public class ShipPlayerParent : CharacterAbstract
{
    public UnityEvent<int> OnHealthChanged;

    protected override void Start()
    {
        base.Start();
        _weaponBehaviour = new BaseWeapon(_bulletReference);
    }

    public override void SetWeaponBehaviour()
    {
        
    }

    public override void Move(Vector2 direction, float angle)
    {
        _rigidBody.AddForce(_speed.CurrentSpeed() * Time.deltaTime * 500f * direction);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public override void Die()
    {
        Destroy(gameObject);
        GameManager.singleton.EndGame();
    }

    public override void Attack()
    {
        _weaponBehaviour.WeaponBehaviour(transform.position, transform.rotation, _power.CurrentPower(), "Enemy");
    }

    public override void ReceiveDamage(int damage)
    {
        base.ReceiveDamage(damage);
        Debug.Log("Player health now: " + _health.GetCurrentHealth());
        Debug.Log("Player armor now: " + _armor.CurrentArmor());
        OnHealthChanged.Invoke(_health.GetCurrentHealth());
    }
}
