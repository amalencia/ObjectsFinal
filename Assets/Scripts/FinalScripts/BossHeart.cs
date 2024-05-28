using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHeart : BossEnemy
{
    [SerializeField] private BossEnemy m_Enemy;
    protected override void Start()
    {
        _armor.InitializeArmor();
        _health.InitializeHealth();
    }

    public override void Die()
    {
        m_Enemy.Die();
    }

    protected override void Update()
    {

    }

    public override void Attack()
    {

    }

    protected override void StartMovement()
    {

    }
    protected override void HorizontalMovement()
    {

    }
    protected override void FixedUpdate()
    {

    }
}
