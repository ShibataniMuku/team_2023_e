using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun_Bullet : MonoBehaviour
{
    [Header("スピード")] public float speed = 1.5f;
    [Header("最大移動距離")] public float maxDistance = 100.0f;
    private Rigidbody2D rb;
    private Vector3 defaultPos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
             Debug.Log("設定が足りません");
             Destroy(this.gameObject);
        }
        defaultPos = transform.position;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float d = Vector3.Distance(transform.position, defaultPos);

        // 最大移動距離を超えている
        if (d > maxDistance)
        {
            Destroy(this.gameObject);
        }
        else
        {
            rb.MovePosition(transform.position + Vector3.down * Time.deltaTime * speed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
         Destroy(this.gameObject);
    }
}