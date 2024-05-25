using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : IWeaponBehaviour
{
    BulletFinal bulletReference;
    GameObject gameObject;
    Vector3 vector3;
    Quaternion rotation;

    public void WeaponBehaviour(Vector2 position, Quaternion rotation, int WeaponPower, string tag)
    {


        BulletFinal tempBullet = GameObject.Instantiate(bulletReference, position, rotation);
        tempBullet.SetUpBullet(tag, WeaponPower);
       
    }

    public BaseWeapon(BulletFinal bulletReference, GameObject gameObject)
    {
        this.bulletReference = bulletReference;
        this.gameObject = gameObject;
    }
}
