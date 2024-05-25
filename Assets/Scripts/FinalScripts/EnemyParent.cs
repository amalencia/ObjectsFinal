using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class EnemyParent : CharacterAbstract
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
    private ShipPlayerParent target;
    [SerializeField] private float _attackDistance;
    [SerializeField] private float _timer;
    [SerializeField] private BulletFinal _bulletReference;
    [SerializeField] protected GameObject _gameObject;

    protected void Start()
    {
        InitiateParameters();
        target = FindObjectOfType<ShipPlayerParent>();

    }

    protected void FixedUpdate()
    {
        if (target != null)
        {

        Vector2 direction = target.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y - transform.position.y, direction.x - transform.position.x) * Mathf.Rad2Deg;
        Move(direction, angle);
    
        }
    }

    public override void InitiateParameters()
    {
        _health = new Health(_healthPoints);
        _armor = new Armor(_armorPoints);
        _speed = new Speed(_baseSpeed);
        _power = new Power(_basePower);
        _weaponBehaviour = new BaseWeapon(_bulletReference, _gameObject);
    }
    public override void Attack()
    {
        
    }

    public override void ReceiveDamage()
    {
        _health.TakeDamage();
        if (_health.GetCurrentHealth() <= 0)
        {
            //Die
            GameManager.singleton.scoreManager.IncreaseScore();
            Destroy(gameObject);
        }
    }

    public override void ReceiveDamage(int damage)
    {
        _health.TakeDamage(damage);
        if(_health.GetCurrentHealth() <= 0)
        {
            //Die
            GameManager.singleton.scoreManager.IncreaseScore();
            Destroy(gameObject);
        }
    }

    public override int GetPower()
    {
        return _power.CurrentPower();
    }

    public override void Move(Vector2 direction, float angle)
    {
        if (target == null)
        {

            return;
        } else 
        { 

            //if distance from target is lesser than attackDistance
            if (Vector2.Distance(target.transform.position, transform.position) > _attackDistance)
            {
                _rigidBody.AddForce(_speed.CurrentSpeed() * 500f * Time.deltaTime * direction.normalized);
                _timer = 0;
            }
            else
            {
                _rigidBody.velocity = Vector2.zero;
                _timer += Time.deltaTime;
                if (_timer > 1f)
                {
                    target.ReceiveDamage();
                    _timer = 0;
                }

            }
            transform.rotation = Quaternion.Euler(0, 0, angle - 90);
        }

    }

    public override void Die()
    {
        
    }
}
