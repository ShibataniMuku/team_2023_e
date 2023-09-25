using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 
 public class Enemy_frameenemy : MonoBehaviour
 {
     #region//インスペクターで設定する
     [Header("移動速度")]public float speed;
     [Header("重力")]public float gravity;
     [Header("画面外でも行動する")] public bool nonVisibleAct;
     #endregion
 
     #region//プライベート変数
     private Rigidbody2D rb = null;
     private SpriteRenderer sr = null;
     private float MoveSpeed = 0.3f;
     
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
         transform.position = new Vector3(0, Mathf.Sin(Time.time) * MoveSpeed, 0);
    }
    else
    {
        rb.Sleep();
    }
}
 }