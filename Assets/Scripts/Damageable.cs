using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField] public int health;

    void Update()
    {
        if (health<=0)
        {
            Destroy(gameObject);
        }
        if (health<=0 && gameObject.CompareTag("Player"))
        {
            LevelManager.instance.Respawn();
            Destroy(gameObject);
        }
    }
}
