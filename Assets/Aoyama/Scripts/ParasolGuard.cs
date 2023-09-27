using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParasolGuard : MonoBehaviour
{
    private Renderer guard;
    private Animator anim = null;

    // Start is called before the first frame update
    void Start()
    {
        //Rendererをコンポーネントから取得
        guard = GetComponent<Renderer>();
        //Annimatorをコンポーネントから取得
        anim = GetComponent<Animator>();

        //オブジェクトを非表示にする
        guard.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //オブジェクトを表示させ、7秒後と10秒後に関数を呼び出す
    public void Guard()
    {
        guard.enabled = true;
        Invoke("Flash",7.0f);
        Invoke("GuardEnd",10.0f);
    }

    //オブジェクトを点滅させる
    private void Flash()
    {
        anim.SetBool("Flashing",true);
    }

    //オブジェクトを非表示にする
    private void GuardEnd()
    {
        guard.enabled = false;
        anim.SetBool("Flashing",false);
    }

    //Arrow Tagのオブジェクトに触れるとそのオブジェクトを破壊する
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "UV" && guard.enabled == true)
        {
            Destroy(collision.gameObject);
        }
        else if(collision.tag == "IR" && guard.enabled == true)
        {
            Destroy(collision.gameObject);
        }
    }
}
