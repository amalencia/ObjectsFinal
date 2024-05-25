using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship1Final : ShipPlayerParent
{
    // Start is called before the first frame update
    void Start()
    {
        InitiateParameters();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void InitiateParameters()
    {
        _health = new Health(_healthPoints);
        _armor = new Armor(_armorPoints);
        _speed = new Speed(_baseSpeed);
        _power = new Power(_basePower);
        _weaponBehaviour = new BaseWeapon(_bulletReference, _gameObject);
    }
}
