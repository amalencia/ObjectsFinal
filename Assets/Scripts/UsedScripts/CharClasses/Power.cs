using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Power", menuName = "Power Class")]
public class Power : ScriptableObject
{
    [SerializeField] private int _power;

    public int CurrentPower()
    {
        return _power;
    }

    public void IncreasePower(int power)
    {
        _power += power;
    }

    public void DecreasePower(int power)
    {
        _power -= power;

        if (_power < 0)
        {
            _power = 0;
        }
    }
}
