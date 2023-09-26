using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UVIR : MonoBehaviour
{
    public float speed = 5.0f; // 速度をインスペクターウィンドウで設定

    private void Update()
    {
        // オブジェクトを下に移動させる
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    // 画面外に出たらオブジェクトを破壊する
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}