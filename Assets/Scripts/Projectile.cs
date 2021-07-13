using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    float projectileSpeed = 15f;

    private void Start()
    {
        Destroy(gameObject, 2.5f);
    }

    void Update()
    {
        transform.position += transform.right * projectileSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Damageable>().health -= 1;
            Destroy(gameObject);
        }
        if (collision.CompareTag("Destructible"))
        {
            collision.GetComponent<Damageable>().health -= 1;
            Destroy(gameObject);
        }
        if (collision.CompareTag("SelfDamage"))
        {
            collision.GetComponentInParent<Damageable>().health -= 3;
            Destroy(gameObject);
        }
    }
}
