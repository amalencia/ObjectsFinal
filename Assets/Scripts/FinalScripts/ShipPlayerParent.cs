using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShipPlayerParent : CharacterAbstract
{
    [Header("Base Parameters")]
    [SerializeField] protected int _healthPoints;
    [SerializeField] protected int _armorPoints;
    [SerializeField] protected int _baseSpeed;
    [SerializeField] protected int _basePower;
    protected Health _health;
    protected Armor _armor;
    protected Speed _speed;
    protected Power _power;
    protected IWeaponBehaviour _weaponBehaviour;
    [SerializeField] protected Rigidbody2D _rigidBody;
    [SerializeField] protected BulletFinal _bulletReference;
    [SerializeField] protected GameObject _gameObject;

    public UnityEvent<int> OnHealthChanged;
    public override void InitiateParameters()
    {
        _health = new Health(_healthPoints);
        _armor = new Armor(_armorPoints);
        _speed = new Speed(_baseSpeed);
        _power = new Power(_basePower);
        _weaponBehaviour = new BaseWeapon(_bulletReference, _gameObject);
    }

    public override void Move(Vector2 direction, float angle)
    {
        _rigidBody.AddForce(_speed.CurrentSpeed() * Time.deltaTime * 500 * direction);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public override void Die()
    {
        Destroy(gameObject);
        GameManager.singleton.EndGame();
    }

    public override int GetPower()
    {
        return _power.CurrentPower();
    }

    public override void Attack()
    {
        _weaponBehaviour.WeaponBehaviour(transform.position, transform.rotation, _power.CurrentPower(), "Enemy");
    }

    public override void ReceiveDamage()
    {
        _health.TakeDamage();
        OnHealthChanged.Invoke(_health.GetCurrentHealth());
        if (_health.GetCurrentHealth() <= 0)
        {
            Die();
        }
    }

    public override void ReceiveDamage(int damage)
    {
        _health.TakeDamage(damage);
        OnHealthChanged.Invoke(_health.GetCurrentHealth());
        Die();
    }
}
