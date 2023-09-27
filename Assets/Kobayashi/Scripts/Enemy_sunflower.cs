using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_sunflower : MonoBehaviour
{
    GameObject Player;
    Vector3 BulletPoint;

    public GameObject Sunflower_bullet;

    private Animator anim = null;

    bool attack = false;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        //Bulletの発射位置を取得
        BulletPoint = transform.Find("BulletPoint").localPosition;
        InvokeRepeating("Attack",1,2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Attack()
    {
        Debug.Log("a");
        Instantiate(Sunflower_bullet,transform.position + BulletPoint,Quaternion.identity);

        anim.SetBool("attack",true);
        Invoke("AnimEnd",0.5f);
    }

    void AnimEnd()
    {
        anim.SetBool("attack",false);;
    }
}