using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 1f;
    private Rigidbody2D rb2d;
    [SerializeField]
    private float deathDelay = 5f;

    [SerializeField]
    private int initialHealth;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = transform.up * moveSpeed;
        StartCoroutine(DeathAfterDelay(deathDelay));
    }

    private IEnumerator DeathAfterDelay(float deathDelay)
    {
        yield return new WaitForSeconds(deathDelay);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider collision)
    {
        IHittable hittable = collision.GetComponent<IHittable>();
        if(hittable != null)
        {
            hittable.GetHit(1, gameObject);
            Destroy(gameObject);
        }
    }
}
