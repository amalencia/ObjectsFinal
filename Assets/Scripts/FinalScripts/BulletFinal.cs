using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFinal : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;
    private Vector3 vector;
    private int power;
    private string targetTag;
    private void Start()
    {
        vector = new Vector3(0, 1, 0);
        Destroy(gameObject, 3f);
    }

    public void SetUpBullet(string tag, int damageParam)
    {
        targetTag = tag;
        power = damageParam;
    }

    private void Update()
    {
        transform.Translate(_bulletSpeed * Time.deltaTime* vector);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag(targetTag))
        {
            collision.GetComponent<CharacterAbstract>().ReceiveDamage(power);
            Destroy(gameObject);
        }
    }
}
