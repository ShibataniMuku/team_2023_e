using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]

public class PlayerMove : MonoBehaviour
{
    GameObject Player;

    private Rigidbody2D rb;
    private bool isFloor = false;
    private int jumpCount = 0;
    public float rightspeed = 4.0f;
    public float leftspeed = -4.0f;
    public float jumpheight = 200f;
    public int MaxJumpCount = 2;
    public FloorCheck floor;
    
    bool right = false;
    bool left = false;

    // Start is called before the first frame update
    void Start()
    {
        //Rigidbodyをコンポーネントから取得
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //接地判定を得る
        isFloor = floor.IsFloor();

        //right = trueなら関数goright()を呼び出す
        if(right)
        {
            goright();
        }
        //left = trueなら関数goleft()を呼び出す
        else if(left)
        {
            goleft();
        }
    }

    //右ボタンを押している間
    public void rPushDown()
    {
        right = true;
    }

    //右ボタンを押すのをやめた時
    public void rPushUp()
    {
        right = false;
    }

    //左ボタンを押している間
    public void lPushDown()
    {
        left = true;
    }

    //左ボタンを押すのをやめた時
    public void lPushUp()
    {
        left = false;
    }

    //Playerが画面内にいるとき、右に移動
    public void goright()
    {
        if(transform.position.x <= 2.32f)
        {
            transform.Translate(new Vector2(rightspeed*Time.deltaTime,0));
        }
    }

    //Playerが画面内にいるとき、左に移動
    public void goleft()
    {
        if(transform.position.x >= -2.32f)
        {
            transform.Translate(new Vector2(leftspeed*Time.deltaTime,0));
        }
    }
    
    //ジャンプボタンが押された＆ジャンプ回数が上限に達していないとき、ジャンプ
    public void jumpClick()
    {
        if(this.jumpCount < MaxJumpCount)
        {
            Debug.Log("ジャンプした");
            rb.velocity = new Vector2(0,jumpheight);
            jumpCount++;
        }
    }

    //地面に触れたらジャンプ可能な回数をリセット
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Floor"))
        {
            if(isFloor)
            {
                Debug.Log("リセット");
                jumpCount = 0;
            }
        }
    }
}
