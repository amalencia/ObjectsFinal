using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeEnemyFinal : EnemyParent
{
    [SerializeField] private ShipExplosion _explosion;
    [SerializeField] private GameObject _explodeObject;
    [SerializeField] private int _explosionMultiplier;
    private bool _stopRotate;

    protected override void Start()
    {
        base.Start();
        _stopRotate = false;
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

        Vector3 rotationVector = new(0, 0, angleToRotate);
        Quaternion _targetRotation = Quaternion.Euler(rotationVector);


        if (_stopRotate)
        {
            return;
        } else if (transform.rotation.eulerAngles.z < lowAngle || transform.rotation.eulerAngles.z > highAngle)
        {
            _rigidBody.velocity = Vector2.zero;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, _targetRotation, _rotateSpeed * Time.deltaTime);
        }
        else if (Vector2.Distance(target.transform.position, transform.position) > _stopDistance)
        {
            _timer = 0;
            _rigidBody.AddForce(_speed.CurrentSpeed() * 500f * Time.deltaTime * direction.normalized);
        }

        if (Vector2.Distance(target.transform.position, transform.position) < _attackDistance)
        {
            Attack();

        }
    }

    public override void Attack()
    {
        _stopRotate = true;
        _rotateSpeed = 0;
        _explosionMultiplier = 1;
        _rigidBody.velocity = Vector2.zero;
        Invoke("Explode", 2f);

    }

    public void Explode()
    {

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
        _explosion._power = _power.CurrentPower();
        _explosion._powerMultiplier = _explosionMultiplier;

        _explodeObject.SetActive(true);
        GameManager.singleton.scoreManager.IncreaseScore();
        Destroy(gameObject, 1f);
    }
}
