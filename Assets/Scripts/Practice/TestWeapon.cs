using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Test Weapon", menuName = "TestWeapon")]
public class TestWeapon : ScriptableObject
{
    [SerializeField] private int damage;
    [SerializeField] private float speed;



}
