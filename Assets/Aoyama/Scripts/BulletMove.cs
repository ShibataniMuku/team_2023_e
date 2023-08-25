using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float Speed = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,Speed * Time.deltaTime,0);
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
