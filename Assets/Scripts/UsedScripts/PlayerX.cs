using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerX : MonoBehaviour
{
    protected Health health;
    protected Armor armor;
    protected Power power;
    protected Speed speed;
    public PlayerX()
    {

    }

    public abstract void SetParameters();




}
