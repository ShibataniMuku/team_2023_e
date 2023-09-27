using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frameenemy_bullet2 : MonoBehaviour
{
    public float Speed = -5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Speed * Time.deltaTime,0,0);
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
