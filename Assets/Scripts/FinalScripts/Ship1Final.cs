using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship1Final : ShipPlayerParent
{
    protected override void Start()
    {
        base.Start();
    }

    public override void SpecialWeapon()
    {
        specialWeaponTimer = 5;
        specialImageTimer.InitializedTimer();
        StartCoroutine(SpecialWeaponEffect());
    }

    protected IEnumerator SpecialWeaponEffect()
    {
        while (specialWeaponTimer > 0)
        {
            yield return new WaitForSeconds(0.1f);

            Attack();
        }
    }


}
