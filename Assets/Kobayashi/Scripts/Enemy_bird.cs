using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_bird : MonoBehaviour
{
    [Header("移動速度")]
    public float speed;
    [Header("重力")]
    public float gravity;
    [Header("画面外でも行動する")]
    public bool nonVisibleAct;
    [Header("プレイヤーを検知する高さ")]
    public float playerDetectionHeight;

    private Rigidbody2D rb = null;
    private SpriteRenderer sr = null;
    private GameObject player; // プレイヤーオブジェクトの参照
    private bool playerDetected = false; // プレイヤーを検知したかどうかのフラグ

    // 追加
    private bool isDead = false;    // 敵が倒れたかどうかのフラグ

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        player = GameObject.FindWithTag("Player"); // プレイヤータグを持つオブジェクトを検索
    }

    void FixedUpdate()
    {
        if (!isDead)
        {
            // プレイヤーのY座標が指定した高さ以下になったら敵が動き始める
            if (!playerDetected && player.transform.position.y >= playerDetectionHeight)
            {
                playerDetected = true; // プレイヤーを検知したらフラグを立てる
            }

            // プレイヤーを検知した場合か、画面内にいる場合に移動
            if (playerDetected || nonVisibleAct && sr.isVisible)
            {
                int xVector = -1;
                rb.velocity = new Vector2(xVector * speed, -gravity);
            }
            else
            {
                rb.Sleep();
            }
        }
        else
        {
            // 敵が倒れたら移動を停止する
            rb.velocity = Vector2.zero;
        }
    }

    public void SetDead(bool dead)
    {
        isDead = dead;
    }
}