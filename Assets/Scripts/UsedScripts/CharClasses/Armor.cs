using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor 
{
    private int _armor;

    public int CurrentArmor()
    {
        return _armor;
    }

    public void TakeArmorDamage(int damage)
    {
        _armor -= damage;
        if (_armor < 0)
        {
            _armor = 0;
        }
    }

    public void TakeArmorDamage()
    {
        _armor--;
        if (_armor < 0)
        {
            _armor = 0;
        }
    }

    public Armor(int armor)
    {
        _armor = armor;
    }
}
