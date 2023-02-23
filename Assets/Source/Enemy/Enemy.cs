using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int initialHealthValue = 5;

    private Health health;

    [SerializeField]
    private GameObject projectile;

    private bool isShooting = false;
    private float speed = 2;
    private float speedVariation = 0.3f;
    public EnemySpawner enemySpawner;

    private void Awake()
    {
        health = GetComponent<Health>();
    }

    private void Start()
    {
        health.InitializeHealth(initialHealthValue);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IHittable hittable = collision.GetComponent<IHittable>();
        if (hittable != null && collision.GetComponent<Player>())
        {
            hittable.GetHit(1, gameObject);
            Death();
        }
    }

    public void EnemyKilledOutsideBounds()
    {
        enemySpawner.EnemyKilled(this, false);
        Destroy(gameObject);
    }

    public void Death()
    {
        enemySpawner.EnemyKilled(this, true);
        StopAllCoroutines();
        Destroy(gameObject);
    }

}
