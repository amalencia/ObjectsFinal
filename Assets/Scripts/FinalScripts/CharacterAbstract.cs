using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterAbstract : MonoBehaviour
{
    [Header("Character Stats")]
    [SerializeField] protected Health _health;
    [SerializeField] protected Armor _armor;
    [SerializeField] protected Power _power;
    [SerializeField] protected Speed _speed;
    [SerializeField] protected IWeaponBehaviour _weaponBehaviour;
    [SerializeField] protected Rigidbody2D _rigidBody;
    [SerializeField] protected BulletFinal _bulletReference;

    protected Coroutine _armorRegen;
    protected Coroutine _armorRegenStarter;

    protected virtual void Start()
    {
        _armor.InitializeArmor();
        _health.InitializeHealth();
    }

    public abstract void SetWeaponBehaviour();

    public abstract void Attack();
    public abstract void Move(Vector2 direction, float angle);

    public abstract void Die();

    protected virtual void ArmorRegenManager()
    {
        if(_armorRegen != null)
        {
            StopCoroutine(_armorRegen);
        }

        if(_armorRegenStarter != null)
        {
            StopCoroutine(_armorRegenStarter);
        }
    }

    public virtual void ReceiveDamage(int damage)
    {
        ArmorRegenManager();
        int damageRemain = _armor.TakeArmorDamage(damage);
        _health.TakeDamage(damageRemain);
        _armorRegenStarter = StartCoroutine(StartArmorRegen());
        if(_health.GetCurrentHealth() <= 0)
        {
            Die();
        }
    }

    IEnumerator StartArmorRegen()
    {
        yield return new WaitForSeconds(4f);

        _armorRegen = StartCoroutine(ArmorRegen());

    }

    IEnumerator ArmorRegen()
    {
        while (_armor.CurrentArmor() < _armor.MaxArmor())
        {
            yield return new WaitForSeconds(1f);

            _armor.ArmorRegen();
        }
    }
}
