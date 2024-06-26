using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class BossEnemy : EnemyParent
{
    [SerializeField] protected BossHeart _bossHeart;
    protected bool _startHorizontal;
    protected bool _startMovement;
    protected Vector3 _movement;
    protected bool _goUp;
    protected override void Start()
    {
        _armor.InitializeArmor();
        _health.InitializeHealth();
        SetWeaponBehaviour();
        _startMovement = true;
        _movement = new Vector3(0, 2.5f, 0);
        _goUp = false;
    }

    protected virtual void Update()
    {
        if (_startMovement)
        {
            StartMovement();
        } else if (_startHorizontal)
        {
            Attack();
            HorizontalMovement();
        }
    }

    public override void Attack()
    {
        _timer += Time.deltaTime;
        if(_timer > 1)
        {
            _timer = 0;
            _weaponBehaviour.WeaponBehaviour(transform.position, transform.rotation, _power.CurrentPower(), "Player");
        }
    }

    protected virtual void StartMovement()
    {
        transform.Translate(Time.deltaTime * _speed.CurrentSpeed() * new Vector3(-1, 0, 0), Space.World);
        if(transform.position.x <= 4)
        {
            _startMovement = false;
            _startHorizontal = true;
        }
    }
    protected virtual void HorizontalMovement()
    {
        if(_goUp)
        {
            transform.Translate(Time.deltaTime * _speed.CurrentSpeed() * _movement, Space.World);
            if(transform.position.y <= -2.5f)
            {
                _goUp = false;
                _movement = -_movement;
            }
        } else
        {
            transform.Translate(Time.deltaTime * _speed.CurrentSpeed() * _movement, Space.World);
            if(transform.position.y >= 2.5f)
            {
                _goUp = true;
                _movement = -_movement;
            }
        }
    }
    protected override void FixedUpdate()
    {
        
    }

    public override void Die()
    {
        GameManager.singleton.scoreManager.IncreaseScore();
        GameManager.singleton.IncreaseGameLevel();
        GameManager.singleton.CreateBossPickup(transform.position);
        Destroy(gameObject);
        Destroy(_bossHeart);
    }
}
