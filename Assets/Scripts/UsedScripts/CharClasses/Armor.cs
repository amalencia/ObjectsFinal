using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Armor", menuName = "Armor Class")]
public class Armor : ScriptableObject
{
    private int _armor;
    [SerializeField] private int _maxArmor;

    public int CurrentArmor()
    {
        return _armor;
    }

    public void InitializeArmor()
    {
        _armor = _maxArmor;
    }

    public int MaxArmor()
    {
        return _maxArmor;
    }

    public int TakeArmorDamage(int damage)
    {
        int overdamage = damage - _armor;
        if(overdamage > 0)
        {
            _armor = 0;
            return overdamage;
        } else
        {
            _armor = -overdamage;
            return 0;
        }
    }

    public void ArmorRegen()
    {
        _armor += 10;
        if (_armor >= _maxArmor)
        {
            _armor = _maxArmor;
        }
    }

    public void IncreaseMaxArmor(int maxIncrease)
    {
        _maxArmor += maxIncrease;
    }
}
