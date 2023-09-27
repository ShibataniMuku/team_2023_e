using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Enemy_frameenemy : MonoBehaviour
{
    GameObject Player;
    Vector3 BulletPoint;

    public GameObject FrameEnemy_bullet1;
    public GameObject FrameEnemy_bullet2;
    public GameObject FrameEnemy_bullet3;
    public float X;
    public float Y;

    private Animator anim = null;
    private float MoveSpeed = 0.3f;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        //Bulletの発射位置を取得
        BulletPoint = transform.Find("BulletPoint").localPosition;
        InvokeRepeating("Attack",1,2);
        X = transform.position.x;
        Y = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Attack()
    {
        Debug.Log("a");
        Instantiate(FrameEnemy_bullet1,transform.position + BulletPoint,Quaternion.identity);
        Instantiate(FrameEnemy_bullet2,transform.position + BulletPoint,Quaternion.identity);
        Instantiate(FrameEnemy_bullet3,transform.position + BulletPoint,Quaternion.identity);

        anim.SetBool("attack",true);
        Invoke("AnimEnd",0.5f);
    }

    void AnimEnd()
    {
        anim.SetBool("attack",false);;
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(X, Mathf.Sin(Time.time) * MoveSpeed + Y, 0);
    }
}