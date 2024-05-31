using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticePickup2 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PickMe();
            collision.gameObject.GetComponent<ShipPlayerParent>().SpecialWeapon();
        }
    }

    protected virtual void PickMe()
    {
        Destroy(gameObject);
    }
}
