using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UVIR : MonoBehaviour
{
    public float speed = 5.0f; // 速度をインスペクターウィンドウで設定

    private SpriteRenderer sr = null;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        if(this.transform.position.y <= -2)
        {
            Destroy(gameObject);
        }
    }

    private void OnWillRenderObject()
    {
        // オブジェクトを下に移動させる
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
}