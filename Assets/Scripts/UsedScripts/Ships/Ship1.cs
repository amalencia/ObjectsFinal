using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship1 //: PlayerX
{
    [Header("Integers")]
    [SerializeField] private int _healthPoints;
    [SerializeField] private int _armorPoints;
    [SerializeField] private int _baseSpeed;
    [SerializeField] private int _basePower;

    private Rigidbody2D _ship1RigidBody;

    public Ship1() : base()
    {
 
    }

    //public override void SetParameters()
    //{
    //    health = new Health(_healthPoints);
    //    armor = new Armor(_armorPoints);
    //    speed = new Speed(_baseSpeed);
    //    power = new Power(_basePower);
    //    _ship1RigidBody = new Rigidbody2D();
    //}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
