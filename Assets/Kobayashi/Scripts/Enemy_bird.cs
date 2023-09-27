using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_bird : MonoBehaviour
{
    [Header("移動速度")]
    public float speed;

    private Rigidbody2D rb = null;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        int xVector = -2;
        rb.velocity = new Vector2(Mathf.Sin(Time.time) * xVector, 0);
    }
}