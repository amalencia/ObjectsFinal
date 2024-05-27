using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class EnemyParent : CharacterAbstract
{
    [Header("Parent Enemy Variables")]
    [SerializeField] protected ShipPlayerParent target;
    [SerializeField] protected float _attackDistance;
    [SerializeField] protected float _timer;
    [SerializeField] protected Vector2 direction;
    [SerializeField] protected float angle;

    //NOTES!!!!
    //1) Check if _timer for attack should be a CoRoutine
    //2) Check what the Move Quaternion does and if still needed

    protected override void Start()
    {
        base.Start();
        target = FindObjectOfType<ShipPlayerParent>();
        SetWeaponBehaviour();
    }

    public override void SetWeaponBehaviour()
    {
        _weaponBehaviour = new BaseWeapon(_bulletReference);
    }

    protected virtual void FixedUpdate()
    {
        if (target != null)
        {
        direction = target.transform.position - transform.position;
            angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            //angle = Mathf.Atan2(direction.y - transform.position.y, direction.x - transform.position.x) * Mathf.Rad2Deg;
        Move(direction, angle);
        }
    }

    public override void Attack()
    {
        
    }

    public override void Move(Vector2 direction, float angle)
    {
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
                target.ReceiveDamage(25); //Need to edit this
                _timer = 0;
            }

        }

        //CHECK WHAT THIS IS DOING!!!!
        transform.rotation = Quaternion.Euler(0, 0, angle - 90);
    }

    public override void Die()
    {
        GameManager.singleton.scoreManager.IncreaseScore();
        Destroy(gameObject);
    }
}
