using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class StandardEnemy : EnemyParent
{
    [SerializeField] private float _angleMargin;

    protected void Update()
    {

    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

    }

    public override void Move(Vector2 direction, float angle)
    {
        float angleToRotate = angle + 270;
        if(angleToRotate > 360)
        {
            angleToRotate -= 360;
        }
        //Debug.Log("angletoRotate is " + angleToRotate);
        //Debug.Log("transform.euler.z is " + transform.rotation.eulerAngles.z);

        float lowAngle = angleToRotate - _angleMargin;
        float highAngle = angleToRotate + _angleMargin;

        if(transform.rotation.eulerAngles.z < lowAngle || transform.rotation.eulerAngles.z > highAngle)
        {
            _rigidBody.velocity = Vector2.zero;
            float newAngle = (angleToRotate - transform.rotation.eulerAngles.z);
            transform.Rotate(0, 0, newAngle*Time.deltaTime*2);//= Quaternion.Euler(0, 0, angleToRotate);
        } else if(Vector2.Distance(target.transform.position, transform.position) > _attackDistance)
        {
            _rigidBody.AddForce(_speed.CurrentSpeed() * 500f * Time.deltaTime * direction.normalized);
            _timer = 0;
        } else
        {
                _rigidBody.velocity = Vector2.zero;
                _timer += Time.deltaTime;
                if (_timer > 0.5f)
                {
                    Attack();
                    _timer = 0;
            }
        }


        //if (_rigidBody.velocity == Vector2.zero)
        //{
        //    transform.rotation = Quaternion.Euler(0, 0, angleToRotate);
        //}
        //Debug.Log("transform.rotation.eulerAngles.z is " + transform.rotation.eulerAngles.z);
        //if (Vector2.Distance(target.transform.position, transform.position) > _attackDistance)
        //{
        //    _rigidBody.AddForce(_speed.CurrentSpeed() * 500f * Time.deltaTime * direction.normalized);
        //    _timer = 0;
        //} else if (Vector2.Distance(target.transform.position, transform.position) <= _attackDistance)
        //{
        //    _rigidBody.velocity = Vector2.zero;
        //    //    _timer += Time.deltaTime;
        //    //    if (_timer > 1f)
        //    //    {
        //    //        Attack();
        //    //        _timer = 0;
        //    //    }
        //}

        




        //if (Vector2.Distance(target.transform.position, transform.position) > _attackDistance)
        //{


            //    _rigidBody.AddForce(_speed.CurrentSpeed() * 500f * Time.deltaTime * direction.normalized);
            //    _timer = 0;
            //}
            //else
            //{
            //    _rigidBody.velocity = Vector2.zero;
            //    _timer += Time.deltaTime;
            //    if (_timer > 1f)
            //    {
            //        Attack();
            //        _timer = 0;
            //    }

            //}
            //transform.rotation = Quaternion.Euler(0, 0, angle - 90);
    }
    public override void Attack()
    {
        _weaponBehaviour.WeaponBehaviour(transform.position, transform.rotation, _power.CurrentPower(), "Player");
    }
}
