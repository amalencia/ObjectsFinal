using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticePickup : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            PickMe();
            collision.gameObject.GetComponent<ShipPlayerParent>().IncreaseNukes();
        }
    }

    protected virtual void PickMe()
    {
        Destroy(gameObject);
    }
}
