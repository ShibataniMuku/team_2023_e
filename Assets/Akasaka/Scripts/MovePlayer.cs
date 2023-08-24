using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float Speed = 5.0f;
    public float JumpPower = 10.0f;
    private Rigidbody2D rb;
    public Vector2 Velocity;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Velocity = new Vector2(0, 0);
    }
    void Update()
    {
        // H/V moving...
        float velocityX = 0.0f;
        float velocityY = rb.velocity.y;
        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            velocityX += 1.0f;
        }
        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            velocityX -= 1.0f;
        }
        if((Input.GetKey(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) && velocityY > -1.0e-5 && velocityY < 1.0e-5)
        {
            velocityY = JumpPower;
        }
        rb.velocity = new Vector2(velocityX * Speed, velocityY);

        // wall...
        if(rb.position.x < -2.6f)
        {
            rb.position = new Vector2(-2.6f, rb.position.y);
        }
        if(rb.position.x > +2.6f)
        {
            rb.position = new Vector2(+2.6f, rb.position.y);
        }
    }
}