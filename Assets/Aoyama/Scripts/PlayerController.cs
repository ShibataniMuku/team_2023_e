using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]

public class PlayerController : MonoBehaviour
{
    GameObject Player;
    Vector3 ShotPoint;

    private Rigidbody2D rb;
    private Animator anim = null;
    private bool isFloor = false;
    private int jumpCount = 0;

    public float rightspeed = 2.0f;
    public float leftspeed = -2.0f;
    public float jumpheight = 200f;
    public int MaxJumpCount = 2;
    public FloorCheck floor;
    public GameObject BulletObj;
    public Slider slider;

    int maxWater = 50;
    int Water;
    
    bool right = false;
    bool left = false;

    // Start is called before the first frame update
    void Start()
    {
        //Rigidbodyをコンポーネントから取得
        rb = GetComponent<Rigidbody2D>();
        //Annimatorをコンポーネントから取得
        anim = GetComponent<Animator>();
        //Bulletの発射位置を取得
        ShotPoint = transform.Find("ShotPoint").localPosition;
        //Sliderを最大にする。
        slider.value = 1;
        //水量を最大水量と同じ値に。
        Water = maxWater;
    }

    // Update is called once per frame
    void Update()
    {
        //接地判定を得る
        isFloor = floor.IsFloor();

        //right = trueなら関数goright()を呼び出す
        if(right)
        {
            GoRight();
        }
        //left = trueなら関数goleft()を呼び出す
        else if(left)
        {
            GoLeft();
        }
    }

    //右ボタンを押している間
    public void RPushDown()
    {
        right = true;
    }

    //右ボタンを押すのをやめた時
    public void RPushUp()
    {
        right = false;
    }

    //左ボタンを押している間
    public void LPushDown()
    {
        left = true;
    }

    //左ボタンを押すのをやめた時
    public void LPushUp()
    {
        left = false;
    }

    //Playerが画面内にいるとき、右に移動
    public void GoRight()
    {
        if(transform.position.x <= 2.054f)
        {
            transform.Translate(new Vector2(rightspeed*Time.deltaTime,0));
            transform.localScale = new Vector3(0.7f,0.7f,1);
        }
    }

    //Playerが画面内にいるとき、左に移動
    public void GoLeft()
    {
        if(transform.position.x >= -2.054f)
        {
            transform.Translate(new Vector2(leftspeed*Time.deltaTime,0));
            transform.localScale = new Vector3(-0.7f,0.7f,1);
        }
    }

    //Bulletを発射   InvokeRepeating("ContinueAttack",0,2);
    public void AttackClick()
    {
        if(slider.value != 0)
        {
            Instantiate(BulletObj,transform.position + ShotPoint,Quaternion.identity);
            
            anim.SetTrigger("Shot");
        
            //水量から1を引く
            Water = Water - 1;
            //水量をSliderに反映。
            slider.value = (float)Water / (float)maxWater;
        }
        else if(slider.value == 0)
        {
            Debug.Log("弾切れ");
        }
    }

    //ジャンプボタンが押された＆ジャンプ回数が上限に達していないとき、ジャンプ
    public void JumpClick()
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