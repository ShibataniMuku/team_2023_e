using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float Speed = 10.0f;

    private GameObject player; 

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.localScale == new Vector3(0.7f,0.7f,1))
        {
            GetComponent<Rigidbody2D>().velocity = Vector3.right * Speed;
            this.enabled = false;
        }
        else if(player.transform.localScale == new Vector3(-0.7f,0.7f,1))
        {
            GetComponent<Rigidbody2D>().velocity = Vector3.left * Speed;
            transform.localScale = new Vector3(-0.5f,0.5f,1);
            this.enabled = false;
        }
        
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
