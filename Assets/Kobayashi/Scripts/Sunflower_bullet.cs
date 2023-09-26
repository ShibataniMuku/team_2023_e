using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sunflower_bullet : MonoBehaviour
{
    [Header("スピード")] public float speed = 3.0f;
    [Header("最大移動距離")] public float maxDistance = 100.0f;
    private Rigidbody2D rb;
    private Vector3 defaultPos;
    
    // スケールを固定サイズに設定
    private Vector3 fixedScale = new Vector3(0.4f, 0.4f, 1.0f);

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

        // オブジェクトのスケールを固定サイズに設定
        transform.localScale = fixedScale;
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
            rb.MovePosition(transform.position + transform.right * Time.deltaTime * speed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
         Destroy(this.gameObject);
    }
}