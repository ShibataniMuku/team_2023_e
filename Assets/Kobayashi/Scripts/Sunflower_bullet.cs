using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sunflower_bullet : MonoBehaviour
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
}