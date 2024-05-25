using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyChild1 : TestEnemy
{
    [SerializeField] private int _healthPoints;
    [SerializeField] private int _armorPoints;
    [SerializeField] private int _baseSpeed;
    [SerializeField] private int _basePower;
    private Health _health;
    private Armor _armor;
    private Speed _speed;
    private Power _power;
    private ITestInterface _testInterface;
    // Start is called before the first frame update
    void Start()
    {
        TestInitiateParams();
        TestAttack();
        TestDie();
        TestMove();
        _testInterface.Fight();
    }

    public override void TestInitiateParams()
    {
        _health = new Health(_healthPoints);
        _armor = new Armor(_armorPoints);
        _speed = new Speed(_baseSpeed);
        _power = new Power(_basePower);
        _testInterface = new TestInterfaceType1();
    }

    public override void TestAttack()
    {
        Debug.Log("Overriding Attack");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
