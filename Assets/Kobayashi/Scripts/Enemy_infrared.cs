using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_infrared : MonoBehaviour
{
    #region//インスペクターで設定する
    [Header("移動速度")] public float speed;
    [Header("重力")] public float gravity;
    [Header("画面外でも行動する")] public bool nonVisibleAct;
    #endregion

    #region//プライベート変数
    private Rigidbody2D rb = null;
    private SpriteRenderer sr = null;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if (sr.isVisible || nonVisibleAct)
        {
            int xVector = -1;
            
            // 下方向に移動するために速度ベクトルを変更
            rb.velocity = new Vector2(xVector * 0, -speed);
        }
        else
        {
            rb.Sleep();
        }
    }
}