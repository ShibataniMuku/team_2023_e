using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_sunflower : MonoBehaviour
{
    [Header("攻撃オブジェクト")] public GameObject attackObj;
    [Header("攻撃間隔")] public float interval;

    private Animator anim;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        if (anim == null || attackObj == null)
        {
            Debug.Log("設定が足りません");
            Destroy(this.gameObject);
        }
        else
        {
            attackObj.SetActive(false);
        }

        InvokeRepeating("Attack",0,2);
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo currentState = anim.GetCurrentAnimatorStateInfo(0);


    }
     
    private void Attack()
    {
        anim.SetTrigger("attack");
        Debug.Log("a");
        GameObject g = Instantiate(attackObj);
        g.transform.SetParent(transform);
        g.transform.position = attackObj.transform.position;
        g.transform.rotation = attackObj.transform.rotation;
        g.SetActive(true);
    }
}