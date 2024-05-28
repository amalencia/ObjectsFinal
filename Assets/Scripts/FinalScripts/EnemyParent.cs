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
    [SerializeField] protected float _stopDistance;
    [SerializeField] protected float _angleMargin;
    [SerializeField] protected float _rotateSpeed;

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
        float angleToRotate = angle + 270;
        if (angleToRotate > 360)
        {
            angleToRotate -= 360;
        }

        float lowAngle = angleToRotate - _angleMargin;
        float highAngle = angleToRotate + _angleMargin;

        Vector3 rotationVector = new (0, 0, angleToRotate);
        Quaternion _targetRotation = Quaternion.Euler(rotationVector);

        if (transform.rotation.eulerAngles.z < lowAngle || transform.rotation.eulerAngles.z > highAngle)
        {
            _rigidBody.velocity = Vector2.zero;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, _targetRotation, _rotateSpeed * Time.deltaTime);
        } else if (Vector2.Distance(target.transform.position, transform.position) > _stopDistance)
        {
            _timer = 0;
            _rigidBody.AddForce(_speed.CurrentSpeed() * 500f * Time.deltaTime * direction.normalized);
        } else
        {
            _rigidBody.velocity = Vector2.zero;
        }

        if(Vector2.Distance(target.transform.position, transform.position) < _attackDistance)
        {
            Attack();
        }
    }

    public override void Die()
    {
        GameManager.singleton.scoreManager.IncreaseScore();
        Destroy(gameObject);
    }
}
