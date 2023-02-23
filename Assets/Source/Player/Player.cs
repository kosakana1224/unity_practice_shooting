using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour,IHittable
{
    public float speed = 2;
    public Transform playerShip;
    public int health = 4;
    public int deathtime = 1;
    public bool isAlive = true;
    Rigidbody2D rb2d;
    Vector2 movementVector = Vector2.zero;

    [SerializeField]
    private Weapon weapon;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        input.Normalize();
        Debug.Log(input);
        movementVector = speed * input;
        if(isAlive == false)
        {
            return;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            weapon.PerformAttack();
        }
    }

    private void FixedUpdate()
    {
        Vector2 newPosition = rb2d.position + movementVector * Time.fixedDeltaTime;
        rb2d.MovePosition(newPosition);
    }
    private void Death()
    {
        isAlive = false;
        GetComponent<Collider2D>().enabled = false;
        GetComponentInChildren<SpriteRenderer>().enabled = false;
        StartCoroutine(DestoryCoroutine());
    }

    private IEnumerator DestoryCoroutine()
    {
        //Instantiate();破壊エフェクト
        yield return new WaitForSeconds(deathtime);
        Destroy(gameObject);
    }

    public void GetHit(int damageValue,GameObject sender)
    {
        health -= damageValue;
        if(health <= 0)
        {
            Death();
        }
        else
        {
            //GetHitFeedback();
        }
    }
}
