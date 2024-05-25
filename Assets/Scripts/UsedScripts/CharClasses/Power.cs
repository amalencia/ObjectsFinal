using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power
{
    private int _power;

    public Power(int power)
    {
        _power = power;
    }

    public int CurrentPower()
    {
        return _power;
    }

    public void IncreasePower(int power)
    {
        _power += power;
    }

    public void IncreasePower()
    {
        _power++;
    }

    public void DecreasePower()
    {
        _power--;
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
