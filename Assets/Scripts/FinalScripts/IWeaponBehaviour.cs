using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeaponBehaviour 
{

    public void WeaponBehaviour(Vector2 position, Quaternion rotation, int WeaponPower, string tag);

}
