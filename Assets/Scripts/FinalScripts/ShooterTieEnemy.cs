using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterTieEnemy : EnemyParent
{
    [SerializeField] private GameObject _pointer;

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

        if (transform.rotation.eulerAngles.z < lowAngle || transform.rotation.eulerAngles.z > highAngle)
        {
            _rigidBody.velocity = Vector2.zero;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, _targetRotation, _rotateSpeed * Time.deltaTime);
        }
        else if (Vector2.Distance(target.transform.position, transform.position) > _stopDistance)
        {
            _timer = 0;
            _rigidBody.AddForce(_speed.CurrentSpeed() * 500f * Time.deltaTime * direction.normalized);
        }
        else
        {
            _rigidBody.velocity = Vector2.zero;
        }

        if (Vector2.Distance(target.transform.position, transform.position) < _attackDistance)
        {
            Attack();
        } else
        {
            _pointer.SetActive(false);
        }
    }
    public override void Attack()
    {
        PointerEnabled();
        _timer += Time.deltaTime;
        if (_timer > 3f)
        {

            _weaponBehaviour.WeaponBehaviour(transform.position, transform.rotation, _power.CurrentPower(), "Player");

            _timer = 0;
        }
    }

    public void PointerEnabled()
    {
        float pointerDistance = Vector2.Distance(target.transform.position, transform.position);
        float pointerScale = pointerDistance / 5;
        float pointerPosition = pointerScale / 2;

        _pointer.transform.localScale = new Vector3 (0.01f, pointerScale, 1);
        _pointer.transform.localPosition = new Vector3 (0, pointerPosition, 0);
        _pointer.SetActive(true);
    }
}
