using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementActionAI : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float speed = 2;
    public float speedVariation = 0.3f;
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        speed += Random.Range(0, speedVariation);
    }

    private void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position * Vector2.down * Time.fixedDeltaTime);
    }
}
