using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frameenemy_bullet1 : MonoBehaviour
{
    public float SpeedX = -5.0f;
    public float SpeedY = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(SpeedX * Time.deltaTime,SpeedY * Time.deltaTime,0);
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