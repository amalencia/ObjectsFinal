using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NukeExplosion : MonoBehaviour
{
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<CharacterAbstract>() != null)
        {
            other.GetComponent<CharacterAbstract>().ReceiveDamage(200);
        }
        else
        {
            Destroy(other.gameObject);
        }

        
    }

}
