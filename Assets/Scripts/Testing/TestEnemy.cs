using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : TestAbstract
{
    public override void TestInitiateParams()
    {
        
    }
    public override void TestAttack()
    {
        Debug.Log("Attack");
    }

    public override void TestMove()
    {
        Debug.Log("Move");
    }

    public override void TestDie()
    {
        Debug.Log("Die");
    }
}
