using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed
{
    private float _baseSpeed;

    public Speed(float speed)
    {
        _baseSpeed = speed;
    }

    public float CurrentSpeed()
    {
        return _baseSpeed;
    }

    public void IncreaseSpeed()
    {
        _baseSpeed++;
    }

    public void IncreaseSpeed(float speed)
    {
        _baseSpeed += speed;
    }

    public void DecreaseSpeed()
    {
        _baseSpeed--;
    }

    public void DecreaseSpeed(float speed)
    {
        _baseSpeed -= speed;
    }
}
