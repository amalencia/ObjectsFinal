using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShipExplosion : MonoBehaviour
{
    [SerializeField] public int _power;
    [SerializeField] public int _powerMultiplier;
    private void Start()
    {
        Destroy(gameObject, 1f);
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<CharacterAbstract>().ReceiveDamage(_power * _powerMultiplier);
    }

}
