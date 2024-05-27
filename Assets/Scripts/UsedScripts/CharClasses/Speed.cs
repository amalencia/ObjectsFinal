using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Speed", menuName = "Speed Class")]
public class Speed : ScriptableObject
{
    [SerializeField] private int _baseSpeed;

    public int CurrentSpeed()
    {
        return _baseSpeed;
    }

    public void IncreaseSpeed(int increase)
    {
        _baseSpeed += increase;
    }

    public void DecreaseSpeed(int speed)
    {
        _baseSpeed -= speed;
    }
}
