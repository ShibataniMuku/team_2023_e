using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Z : MonoBehaviour
{
    #region//インスペクターで設定する
    [Header("移動速度")]
    public float speed;
    [Header("重力")]
    public float gravity;
    [Header("画面外でも行動する")]
    public bool nonVisibleAct;
    #endregion

    #region//プライベート変数
    private Rigidbody2D rb = null;
    private SpriteRenderer sr = null;
    private int hp = 1; // 敵のHP
     private bool isDead = false;    // 敵が倒れたかどうかのフラグ
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if(!isDead)
        {
            if (sr.isVisible || nonVisibleAct)
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